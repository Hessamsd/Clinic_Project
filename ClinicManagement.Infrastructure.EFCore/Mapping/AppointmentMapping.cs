using ClinicManagement.Domain.AppointmentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.EFCore.Mapping
{
    public class AppointmentMapping : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.AppointmentDate).IsRequired();
            builder.Property(a => a.DoctorId).IsRequired();
            builder.Property(a => a.PatientId).IsRequired();




            builder.HasOne(a => a.Doctor)
                .WithMany(a => a.Appointments)
                .HasForeignKey(a => a.DoctorId);


            builder.HasOne(a => a.Patient)
                .WithMany(a => a.Appointments)
                .HasForeignKey(a=>a.PatientId);
        }
    }
}
