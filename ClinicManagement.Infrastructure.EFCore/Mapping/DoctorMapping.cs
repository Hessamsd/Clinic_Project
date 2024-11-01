using ClinicManagement.Domain.DoctorAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.EFCore.Mapping
{
    public class DoctorMapping : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {

            builder.ToTable("Doctors");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x=> x.Photo).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Specialty).IsRequired().HasMaxLength(100);
            builder.Property(x => x.MedicalLicenseNumber).IsRequired().HasMaxLength(7);
            builder.Property(x => x.ClinicNumber).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Biography).IsRequired().HasMaxLength(500);



            builder.HasMany(x=>x.Appointments)
                .WithOne(x=> x.Doctor)
                .HasForeignKey(x=>x.DoctorId);


            builder.HasMany(x => x.DoctorSecretaries)
                .WithOne(x => x.Doctor)
                .HasForeignKey(x => x.DoctorId);


        }
    }
}
