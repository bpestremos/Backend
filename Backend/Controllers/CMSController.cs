using Backend.Interface;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CMSController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<CMSController> _logger;
        private readonly ICMSService _service;

        public CMSController(ILogger<CMSController> logger, ICMSService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("GetCMS")]
        public IActionResult GetCMS()
        {
            return Ok(_service.GetCMS());
        }

        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            return Ok(_service.GetEmployees());
        }

        [HttpPost]
        [Route("CreateEmployees")]
        public IActionResult CreateEmployees(EmployeesDto employees)
        {
            try
            {
                return Ok(_service.CreateEmployee(employees));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateEmployees")]
        public IActionResult UpdateEmployee(EmployeesDto employees)
        {
            try
            {
                return Ok(_service.UpdateEmployee(employees));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteEmployees/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var result = Ok(_service.DeleteEmployee(id));

                if (result == null || (int)result.Value == 0)
                    return NotFound();

                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}