using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareConcept.Middleware
{
    public static class ClientConfigurationMiddlewareExtension
    {
        public static void UseClientConfiguration(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ClientConfigurationMiddleware>();
        }
    }
}
