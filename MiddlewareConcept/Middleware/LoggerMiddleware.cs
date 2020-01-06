using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareConcept.Middleware
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _delegate;
        private readonly ILogger _logger;

        public LoggerMiddleware(RequestDelegate reqDelegate, ILoggerFactory loggerFactory)
        {
            _delegate = reqDelegate;
            _logger = loggerFactory.CreateLogger<LoggerMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(context.Request.Body))
            {
                body = reader.ReadToEnd();
                //Log Request Body
                Console.WriteLine(context.Request.Body);
                _logger.LogInformation(body);
            }
                
            await _delegate(context);
        }
    }
}
