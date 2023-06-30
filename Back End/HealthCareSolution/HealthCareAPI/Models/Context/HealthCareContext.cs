using Microsoft.EntityFrameworkCore;

namespace HealthCareAPI.Models.Context
{
    public class HealthCareContext:DbContext
    {
        public HealthCareContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

    }
}
