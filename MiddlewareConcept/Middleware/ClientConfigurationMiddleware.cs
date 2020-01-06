using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareConcept.Middleware
{
    public class ClientConfigurationMiddleware
    {
        private readonly RequestDelegate _delegate;
        private readonly ILogger _logger;

        public ClientConfigurationMiddleware(RequestDelegate reqDelegate, ILoggerFactory loggerFactory)
        {
            _delegate = reqDelegate;
            _logger = loggerFactory.CreateLogger<LoggerMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context, IClientConfiguration clientConfiguration)
        {
            string clientName = string.Empty;
            DateTime invokedTime = DateTime.UtcNow;


            if (context.Request.Headers.TryGetValue("ClientName", out StringValues clientNames))
            {
                clientName = clientNames.FirstOrDefault();
            }

            clientConfiguration.ClientName = clientName;
            clientConfiguration.InvokedTime = invokedTime;

            await _delegate(context);
        }
    }
}
