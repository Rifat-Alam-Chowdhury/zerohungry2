using BAL.Model;
using BAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        EmployeeService service;

        public EmployeeController(EmployeeService service)
        {
            this.service = service;

        }



        [HttpGet("All_Employees")]
        public IActionResult GetAllEmployees()
        {
            var Employees = service.GetAllEmployees();
            return Ok(Employees);
        }
        [HttpGet("Employee/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var Employee = service.GetEmployeeById(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(EmployeeModel EmployeeModel)
        {
            var data = service.AddEmployee(EmployeeModel);
            return Ok(data);
        }
        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(EmployeeModel EmployeeModel)
        {
            var data = service.UpdateEmployee(EmployeeModel);
            return Ok(data);
        }
        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var data = service.DeleteEmployee(id);
            return Ok(data);
        }
    }
}
