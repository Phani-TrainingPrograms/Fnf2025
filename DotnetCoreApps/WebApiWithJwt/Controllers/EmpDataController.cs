using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApiWithJwt.Models;

namespace WebApiWithJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class EmpDataController : ControllerBase
    {
        private readonly IEmpService empService;
        public EmpDataController(IEmpService empService)
        {
            this.empService = empService;
        }

        [HttpGet]
        public async Task<IActionResult> AllEmployees()
        {
            var model  = await empService.GetAllEmployees();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Employee(int id)
        {
            var model = await empService.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(Employee emp)
        {
            var model = await empService.AddNewEmployee(emp);
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee emp)
        {
            var model = await empService.UpdateEmployee(emp);
            return Ok(model);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await empService.DeleteEmployee(id);
                return Ok("Employee deleted successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
