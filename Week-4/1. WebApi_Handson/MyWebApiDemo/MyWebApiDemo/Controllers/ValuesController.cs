using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyWebApiDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: /values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: /values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value" + id;
        }

        // POST: /values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: /values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: /values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
