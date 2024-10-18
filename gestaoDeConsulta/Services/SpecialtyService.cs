
using AutoMapper;
using gestaoDeConsulta.DTOs;
using gestaoDeConsulta.Models;
using gestaoDeConsulta.Repositories.Interface;
using gestaoDeConsulta.Services.Interfaces;

namespace gestaoDeConsulta.Services
{
    public class SpecialtyService : ISpecialtyService
    {


        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IMapper _mapper;

        public SpecialtyService(ISpecialtyRepository specialtyRepository, IMapper mapper)
        {
            _specialtyRepository = specialtyRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<SpecialtyDTO>>> GetAllAsync()
        {
            var specialtyList = await _specialtyRepository.GetAllAsync();

            IEnumerable<SpecialtyDTO> specialtyListDTO = _mapper.Map<IEnumerable<SpecialtyDTO>>(specialtyList);

            return ApiResponse<IEnumerable<SpecialtyDTO>>.Success(data: specialtyListDTO.ToList());
        }

        public async Task<ApiResponse<SpecialtyDTO>> GetByIdAsync(Guid id)
        {
            var specialty = await _specialtyRepository.GetByIdAsync(id);

            if( specialty == null)
            {
                return ApiResponse<SpecialtyDTO>.Fail(statusCode: 404, message: "Nenhuma especialidade encontrada");
            }

            SpecialtyDTO specialtyDTO = _mapper.Map<SpecialtyDTO>(specialty);

            return ApiResponse<SpecialtyDTO>.Success(data: specialtyDTO);
        }

        public async Task<ApiResponse<CreateSpecialtyDTO>> CreateAsync(CreateSpecialtyDTO createSpecialtyDTO)
        {

            Specialty specialty = _mapper.Map<Specialty>(createSpecialtyDTO);

            await _specialtyRepository.CreateAsync(specialty);

            return ApiResponse<CreateSpecialtyDTO>.Success(data: createSpecialtyDTO);
        }
        public async Task<ApiResponse<UpdateSpecialtyDTO>> UpdateAsync(Guid id, UpdateSpecialtyDTO updateSpecialtyDTO)
        {
            var specialty = await _specialtyRepository.GetByIdAsync(id);

            if(specialty == null)
            {
                return ApiResponse<UpdateSpecialtyDTO>.Fail(statusCode: 400, message: "Especialidade não encontrada");
            }

            specialty.ChangeName(updateSpecialtyDTO.Name);
            specialty.ChangeDescription(updateSpecialtyDTO.Description);

            await _specialtyRepository.UpdateAsync(specialty);

            return ApiResponse<UpdateSpecialtyDTO>.Success(data: updateSpecialtyDTO);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(Guid id)
        {
            var specialty = await _specialtyRepository.GetByIdAsync(id);

            if ( specialty == null )
            {
                return ApiResponse<bool>.Fail(statusCode: 400, message: "Especialidade não encontrada");
            }

            await _specialtyRepository.DeleteAsync(id);

            return ApiResponse<bool>.Success(data: true);
        }
    }
}
