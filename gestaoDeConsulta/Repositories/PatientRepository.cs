using gestaoDeConsulta.Context;
using gestaoDeConsulta.DTOs;
using gestaoDeConsulta.Models;
using gestaoDeConsulta.Repositories.Interface;
using gestaoDeConsulta.Utilities;
using Microsoft.EntityFrameworkCore;

namespace gestaoDeConsulta.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {

        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Patient> FindByEmailAsync(string email)
        {
            return await _context.Patients.Where(p => p.Email == email).FirstOrDefaultAsync();
        }
        
        public async Task<Patient> FindByCPFAsync(string cpf)
        {
            return await _context.Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.CPF == cpf);
        }
    }
}
