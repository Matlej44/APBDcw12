using APBDcw12.Data;
using APBDcw12.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBDcw12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients([FromQuery] string? search)
        {
            try
            {
                var result = 
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        } 
    }
}
