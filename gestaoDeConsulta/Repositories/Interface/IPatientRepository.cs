using gestaoDeConsulta.Models;

namespace gestaoDeConsulta.Repositories.Interface
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<Patient> FindByEmailAsync(string email);
        Task<Patient> FindByCPFAsync(string cpf);

    }
}
