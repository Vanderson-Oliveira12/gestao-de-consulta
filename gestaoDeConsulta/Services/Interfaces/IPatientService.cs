using gestaoDeConsulta.DTOs;

namespace gestaoDeConsulta.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDTO>> GetAllAsync();
        Task<PatientDTO> GetByIdAsync(Guid id);
        Task<PatientDTO> CreateAsync(PatientDTO model);
        Task<PatientDTO> UpdateAsync(PatientDTO model);
        Task DeleteAsync(Guid id);

    }
}
