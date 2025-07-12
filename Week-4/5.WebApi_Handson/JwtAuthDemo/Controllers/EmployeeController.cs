using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin,POC")] // ✅ Only users with Admin or POC role can access
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("✅ Access granted to EmployeeController");
        }
    }
}
