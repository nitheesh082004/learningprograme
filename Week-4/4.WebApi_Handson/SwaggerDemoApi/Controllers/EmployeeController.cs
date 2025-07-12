using Microsoft.AspNetCore.Mvc;
using SwaggerDemoApi.Filters;
using SwaggerDemoApi.Models;

namespace SwaggerDemoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter] // 🔐 Applies custom filter
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
        [ProducesResponseType(typeof(List<Employee>), 200)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(employees);
        }

        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee emp)
        {
            emp.Id = employees.Max(e => e.Id) + 1;
            employees.Add(emp);
            return Ok(emp);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(400)]
        public ActionResult<Employee> Put([FromBody] Employee emp)
        {
            if (emp.Id <= 0)
                return BadRequest("Invalid employee id");

            var existing = employees.FirstOrDefault(e => e.Id == emp.Id);
            if (existing == null)
                return BadRequest("Invalid employee id");

            // Update data
            existing.Name = emp.Name;
            existing.Salary = emp.Salary;
            existing.Permanent = emp.Permanent;
            existing.Department = emp.Department;
            existing.Skills = emp.Skills;
            existing.DateOfBirth = emp.DateOfBirth;

            return Ok(existing);
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
