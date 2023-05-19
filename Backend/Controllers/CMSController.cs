using Backend.Data.DTO;
using Backend.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CMSController : ControllerBase
    {

        private readonly ILogger<CMSController> _logger;
        private readonly ICMSService _service;

        public CMSController(ILogger<CMSController> logger, ICMSService service)
        {
            _logger = logger;
            _service = service;
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
            catch (InvalidOperationException error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
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
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteEmployees/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var result = Ok(_service.DeleteEmployee(id));

                if (result.Value.ToString() == "0" || result == null)
                    return NotFound();

                return result;
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }
    }
}