using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccessLayer;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultsController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        { 
            using (var c = new Context())
            {
                var values = c.Employees.ToList();
                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee model)
        {
            using (var c = new Context())
            {
                c.Add(model);
                c.SaveChanges();
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using (var c = new Context())
            {
                var employee = c.Employees.Find(id);
                if (employee == null)
                    return NotFound();
                return Ok(employee);
            }
        }

        [HttpDelete]
        public IActionResult EmployeeDelete(int id)
        {
            using (var c = new Context())
            {
                var employee = c.Employees.Find(id);
                if (employee == null)
                    return NotFound();
                
                c.Remove(employee);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee model)
        {
            using (var c = new Context())
            {
                var emp = c.Find<Employee>(model.Id);
                if (emp == null)
                    return NotFound();

                emp.Name = model.Name;
                c.Update(emp);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
