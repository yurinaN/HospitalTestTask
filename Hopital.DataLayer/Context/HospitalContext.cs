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

        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<HealthLocality> HealthLocalities { get; set; }
        public DbSet<LocalDoctor> LocalDoctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

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
