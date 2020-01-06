using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareConcept.Middleware
{
    public static class LoggerMiddlewareExtension
    {
        public static void UseLogger(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<LoggerMiddleware>();
        }
    }
}
