using gestaoDeConsulta.Context;
using gestaoDeConsulta.Models;
using gestaoDeConsulta.Repositories.Interface;

namespace gestaoDeConsulta.Repositories
{
    public class SpecialtyRepository : BaseRepository<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(AppDbContext context) : base(context)
        {

        }
    }
}
