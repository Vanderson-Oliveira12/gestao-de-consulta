using gestaoDeConsulta.DTOs;
using gestaoDeConsulta.Models;
using gestaoDeConsulta.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gestaoDeConsulta.Controllers
{
    [Route("api/specialties")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {

        private readonly ISpecialtyService _specialtyService;

        public SpecialtyController(ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Specialty>>>> GetAllSpecialty()
        {

            var response = await _specialtyService.GetAllAsync();

            if ( response.IsSuccess )
            {

                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialtyDTO>> GetSpecialtyById(Guid id)
        {
            var response = await _specialtyService.GetByIdAsync(id);

            if ( response.IsSuccess ) {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<CreateSpecialtyDTO>>> CreateSpecialty([FromBody] CreateSpecialtyDTO createSpecialtyDTO)
        {
            var response = await _specialtyService.CreateAsync(createSpecialtyDTO);

            if ( response.IsSuccess ) {

                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<ApiResponse<UpdateSpecialtyDTO>>> UpdateSpecialty(Guid id,[FromBody] UpdateSpecialtyDTO updateSpecialtyDTO)
        {
            var response = await _specialtyService.UpdateAsync(id, updateSpecialtyDTO);

            if ( response.IsSuccess ) {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteSpecialty(Guid id)
        {

            var response = await _specialtyService.DeleteAsync(id);

            if ( response.IsSuccess ) {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }
    }
}
