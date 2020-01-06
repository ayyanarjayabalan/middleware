using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MiddlewareConcept.AppConfiguration;
using MiddlewareConcept.Middleware;

namespace MiddlewareConcept.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IClientConfiguration _clientConfiguration;
        IOptions<MailConfiguration> _mailConfiguration;

        public ValuesController(IClientConfiguration clientConfiguration, IOptions<MailConfiguration> mailConfiguration)
        {
            _clientConfiguration = clientConfiguration;
            _mailConfiguration = mailConfiguration;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            Console.WriteLine(_clientConfiguration.ClientName);
            return new string[] { _clientConfiguration.ClientName, _clientConfiguration.InvokedTime.ToString(), _mailConfiguration.Value.FromName };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
