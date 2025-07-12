using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SwaggerDemoApi.Controllers
{
    [ApiController]
    [Route("Emp")] // This sets route to /emp
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string> { "John", "Priya", "Amit", "Sara" };
        }
    }
}
