using gestaoDeConsulta.DTOs;
using gestaoDeConsulta.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gestaoDeConsulta.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetAllPatients()
        {

            var response = await _patientService.GetAllAsync();

            return Ok(response);
        }

    }
}
