using AutoMapper;
using gestaoDeConsulta.DTOs;
using gestaoDeConsulta.Models;

namespace gestaoDeConsulta.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
        }
    }
}
