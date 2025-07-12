using Microsoft.AspNetCore.Mvc;
using SwaggerDemoApi.Filters;
using SwaggerDemoApi.Models;     // Your model classes

namespace SwaggerDemoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter] // ✅ Custom filter applied here
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees;

        public EmployeeController()
        {
            if (employees == null || !employees.Any())
            {
                employees = GetStandardEmployeeList();
            }
        }

        [HttpGet]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> GetStandard()
        {
            throw new Exception("Forced exception for testing");
        }


        [HttpPost]
        public ActionResult<Employee> Post(Employee emp)
        {
            emp.Id = employees.Max(e => e.Id) + 1;
            employees.Add(emp);
            return Ok(emp);
        }

        [HttpPut]
        public ActionResult<Employee> Put(Employee emp)
        {
            var index = employees.FindIndex(e => e.Id == emp.Id);
            if (index >= 0)
            {
                employees[index] = emp;
                return Ok(emp);
            }
            return NotFound();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 50000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Department = new Department { Id = 101, Name = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "SQL" }
                    }
                },
                new Employee
                {
                    Id = 2,
                    Name = "Alice Smith",
                    Salary = 60000,
                    Permanent = false,
                    DateOfBirth = new DateTime(1992, 5, 20),
                    Department = new Department { Id = 102, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 3, Name = "Excel" }
                    }
                }
            };
        }
    }
}
