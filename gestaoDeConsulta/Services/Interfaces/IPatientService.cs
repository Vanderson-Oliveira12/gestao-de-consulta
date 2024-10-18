using gestaoDeConsulta.DTOs;
using gestaoDeConsulta.Models;

namespace gestaoDeConsulta.Services.Interfaces
{
    public interface IPatientService
    {
        Task<ApiResponse<IEnumerable<PatientDTO>>> GetAllAsync();
        Task<ApiResponse<PatientDTO>> GetByIdAsync(Guid id);
        Task<ApiResponse<CreatePatientDTO>> CreateAsync(CreatePatientDTO model);
        Task<ApiResponse<UpdatePatientDTO>> UpdateAsync(Guid id, UpdatePatientDTO model);
        Task<ApiResponse<bool>> DeleteAsync(Guid id);

    }
}
