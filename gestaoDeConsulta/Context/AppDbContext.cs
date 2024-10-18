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
        public DbSet<Specialty> Specialtys { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Specialty>()
                .HasMany(s => s.Doctors)
                .WithMany(d => d.Specialtys);
        }
    }
}
