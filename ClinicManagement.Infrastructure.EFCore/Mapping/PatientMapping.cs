using ClinicManagement.Domain.PatientAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.EFCore.Mapping
{
    public class PatientMapping : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Age).IsRequired();
            builder.Property(p => p.ContactNumber).IsRequired().HasMaxLength(15);
            builder.Property(p => p.City).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);


            builder.HasMany(p => p.Appointments)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);
        }
    }
}
