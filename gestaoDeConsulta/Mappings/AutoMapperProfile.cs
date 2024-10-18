using AutoMapper;
using gestaoDeConsulta.DTOs;
using gestaoDeConsulta.Models;
using gestaoDeConsulta.Utilities;

namespace gestaoDeConsulta.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<CreatePatientDTO, Patient>()
                .BeforeMap((src, dest) =>
                {
                    var cpfClear = FormatCpf.CleanCpf(src.CPF);

                    dest.ChangeCPF(cpfClear);
                })
                .ReverseMap();

            CreateMap<Specialty, SpecialtyDTO>().ReverseMap();
            CreateMap<Specialty, CreateSpecialtyDTO>().ReverseMap();
        }
    }
}
