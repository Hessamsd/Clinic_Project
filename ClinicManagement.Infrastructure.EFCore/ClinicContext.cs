using ClinicManagement.Domain.AppointmentAgg;
using ClinicManagement.Domain.DoctorAgg;
using ClinicManagement.Domain.DoctorSecretaryAgg;
using ClinicManagement.Domain.PatientAgg;
using ClinicManagement.Domain.SecretaryAgg;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Infrastructure.EFCore
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorSecretary> DoctorSecretaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
