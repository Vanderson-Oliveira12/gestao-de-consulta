using gestaoDeConsulta.Context;
using gestaoDeConsulta.Models;
using gestaoDeConsulta.Repositories.Interface;

namespace gestaoDeConsulta.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context)
        {

        }
    }
}
