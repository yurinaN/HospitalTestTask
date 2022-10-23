using Hopital.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hopital.DataLayer.Context
{
    public class HospitalContext : DbContext
    {
        private readonly IConfiguration configuration;

        public HospitalContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Cabinet> Cabinets => Set<Cabinet>();
        public DbSet<HealthLocality> HealthLocalities => Set<HealthLocality>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Specialization> Specializations => Set<Specialization>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("HospitalContext");
            optionsBuilder.UseSqlServer(connectionString)
                          .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
