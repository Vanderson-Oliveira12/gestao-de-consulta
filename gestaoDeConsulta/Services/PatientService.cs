using AutoMapper;
using gestaoDeConsulta.DTOs;
using gestaoDeConsulta.Models;
using gestaoDeConsulta.Repositories.Interface;
using gestaoDeConsulta.Services.Interfaces;
using gestaoDeConsulta.Utilities;
using Microsoft.AspNetCore.Identity;

namespace gestaoDeConsulta.Services
{
    public class PatientService : IPatientService
    {

        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;
        private readonly ILogger<PatientService> _logger;

        public PatientService(IMapper mapper, IPatientRepository patientRepository, ILogger<PatientService> logger)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
            _logger = logger;
        }

        public async Task<ApiResponse<IEnumerable<PatientDTO>>> GetAllAsync()
        {
            IEnumerable<Patient> patients = await _patientRepository.GetAllAsync();

            IEnumerable<PatientDTO> patientsDTO = _mapper.Map<IEnumerable<PatientDTO>>(patients).ToList();

            return ApiResponse<IEnumerable<PatientDTO>>.Success(data: patientsDTO);
        }

        public async Task<ApiResponse<PatientDTO>> GetByIdAsync(Guid id)
        {

            Patient patient = await _patientRepository.GetByIdAsync(id);

            if ( patient == null )
            {
                return ApiResponse<PatientDTO>.Fail(statusCode: 404, message: "Paciente não encontrado");
            }

            PatientDTO patietnDTO = _mapper.Map<PatientDTO>(patient);

            return ApiResponse<PatientDTO>.Success(data: patietnDTO);
        }

        public async Task<ApiResponse<CreatePatientDTO>> CreateAsync(CreatePatientDTO createPatientDTO)
        {

            Patient emailAlreadyExists = await _patientRepository.FindByEmailAsync(createPatientDTO.Email);

            if ( emailAlreadyExists != null )
            {
                return ApiResponse<CreatePatientDTO>.Fail(statusCode: 400, message: "Paciente com esse e-mail já registrado!");
            }

            string cpfClean = FormatCpf.CleanCpf(createPatientDTO.CPF);

            Patient cpfAlreadyExists = await _patientRepository.FindByCPFAsync(cpfClean);

            if ( cpfAlreadyExists != null )
            {
                return ApiResponse<CreatePatientDTO>.Fail(statusCode: 400, message: "Paciente com esse CPF já registrado!");
            }

            Patient patient = _mapper.Map<Patient>(createPatientDTO);

            await _patientRepository.CreateAsync(patient);

            return ApiResponse<CreatePatientDTO>.Success(data: createPatientDTO);
        }

        public async Task<ApiResponse<UpdatePatientDTO>> UpdateAsync(Guid id, UpdatePatientDTO updatePatientDTO)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            if(patient is null )
            {
                return ApiResponse<UpdatePatientDTO>.Fail(statusCode: 404, message: "Paciente não encontrado");
            }

            if(id != patient.Id)
            {
                return ApiResponse<UpdatePatientDTO>.Fail(statusCode: 400, message: "Identificação divergente");
            }

            patient.ChangeName(updatePatientDTO.Name);
            patient.ChangePhone(updatePatientDTO.Phone);
            patient.ChangeAddress(updatePatientDTO.Address);
            patient.changeDateOfBirth(updatePatientDTO.DateOfBirth);

            await _patientRepository.UpdateAsync(patient);  

            return ApiResponse<UpdatePatientDTO>.Success(data: updatePatientDTO);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(Guid id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            if ( patient is null )
            {
                return ApiResponse<bool>.Fail(statusCode: 404, message: "Paciente não encontrado");
            }

            await _patientRepository.DeleteAsync(id);

            return ApiResponse<bool>.Success(data: true, message: "Paciente deletado com sucesso");
        }
    }
}
