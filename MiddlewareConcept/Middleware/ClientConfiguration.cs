using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareConcept.Middleware
{
    public class ClientConfiguration : IClientConfiguration
    {
        public string ClientName { get; set; }
        public DateTime InvokedTime { get; set; }
    }
}
