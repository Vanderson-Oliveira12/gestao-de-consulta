using gestaoDeConsulta.DTOs;
using gestaoDeConsulta.Models;
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
        public async Task<ActionResult<ApiResponse<IEnumerable<PatientDTO>>>> GetAllPatients()
        {

            var response = await _patientService.GetAllAsync();

            if ( response.IsSuccess )
            {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PatientDTO>>> GetPatientById(Guid id)
        {
            var response = await _patientService.GetByIdAsync(id);

            if ( response.IsSuccess )
            {

                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<CreatePatientDTO>>> CreatePatient([FromBody] CreatePatientDTO createPatientDTO)
        {

            var response = await _patientService.CreateAsync(createPatientDTO);

            if ( response.IsSuccess )
            {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UpdatePatientDTO>> UpdatePatient(Guid id, [FromBody] UpdatePatientDTO updatePatientDTO)
        {

            var response = await _patientService.UpdateAsync( id, updatePatientDTO);

            if ( response.IsSuccess ) {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeletePatient(Guid id)
        {

            var response = await _patientService.DeleteAsync(id);

            if ( response.IsSuccess )
            {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }

    }
}
