using gestaoDeConsulta.Models;
using Microsoft.EntityFrameworkCore;

namespace gestaoDeConsulta.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Patient> Patients { get; set; }
    }
}
