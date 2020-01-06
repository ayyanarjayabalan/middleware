using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareConcept.Middleware
{
    public interface IClientConfiguration
    {
        string ClientName { get; set; }

        DateTime InvokedTime { get; set; }
    }
}
