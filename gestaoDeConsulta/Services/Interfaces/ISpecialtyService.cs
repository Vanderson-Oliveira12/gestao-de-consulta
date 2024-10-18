using gestaoDeConsulta.DTOs;
using gestaoDeConsulta.Models;

namespace gestaoDeConsulta.Services.Interfaces
{
    public interface ISpecialtyService
    {
        Task<ApiResponse<IEnumerable<SpecialtyDTO>>> GetAllAsync();
        Task<ApiResponse<SpecialtyDTO>> GetByIdAsync(Guid id);
        Task<ApiResponse<CreateSpecialtyDTO>> CreateAsync(CreateSpecialtyDTO createSpecialtyDTO);
        Task<ApiResponse<UpdateSpecialtyDTO>> UpdateAsync(Guid id, UpdateSpecialtyDTO updateSpecialtyDTO);
        Task<ApiResponse<bool>> DeleteAsync(Guid id);

    }
}
