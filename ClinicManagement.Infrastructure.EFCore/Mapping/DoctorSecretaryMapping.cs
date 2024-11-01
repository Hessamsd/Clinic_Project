using ClinicManagement.Domain.DoctorSecretaryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.EFCore.Mapping
{
    public class DoctorSecretaryMapping : IEntityTypeConfiguration<DoctorSecretary>
    {
        public void Configure(EntityTypeBuilder<DoctorSecretary> builder)
        {
            builder.ToTable("DoctorSecretary");

            builder.HasKey(ds => new { ds.DoctorId, ds.SecretaryId });

            builder.HasOne(ds => ds.Doctor)
                .WithMany(ds => ds.DoctorSecretaries)
                .HasForeignKey(ds => ds.DoctorId);



            builder.HasOne(ds => ds.Secretary)
                .WithMany(ds => ds.DoctorSecretaries)
                .HasForeignKey(ds=> ds.SecretaryId);

        }
    }
}
