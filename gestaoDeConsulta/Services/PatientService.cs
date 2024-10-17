using AutoMapper;
using gestaoDeConsulta.DTOs;
using gestaoDeConsulta.Models;
using gestaoDeConsulta.Repositories.Interface;
using gestaoDeConsulta.Services.Interfaces;

namespace gestaoDeConsulta.Services
{
    public class PatientService : IPatientService
    {

        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public PatientService(IMapper mapper, IPatientRepository patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<PatientDTO>> GetAllAsync()
        {
            IEnumerable<Patient> patients = await _patientRepository.GetAllAsync();
           
            IEnumerable<PatientDTO> patientsDTO = _mapper.Map<IEnumerable<PatientDTO>>(patients).ToList();

            return patientsDTO;
        }

        public Task<PatientDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<PatientDTO> CreateAsync(PatientDTO model)
        {
            throw new NotImplementedException();
        }
        public Task<PatientDTO> UpdateAsync(PatientDTO model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
