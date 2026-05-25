using APBDcw12.Data;
using APBDcw12.DTOs.CreateBedAssigment;
using APBDcw12.Exception;
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
                var result = await _patientService.GetPatientAsync(search);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [Route("{pesel}/bedassignments")]
        [HttpPost]
        public async Task<IActionResult> CreateBedAssignment(string pesel, [FromBody] CreateBedAssigmentDTO bedAssignment)
        {
            try
            {
                await _patientService.AddBedAssignmentAsync(pesel, bedAssignment);
                return Created();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
