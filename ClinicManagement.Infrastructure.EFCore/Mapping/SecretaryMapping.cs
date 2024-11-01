using ClinicManagement.Domain.SecretaryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.EFCore.Mapping
{
    public class SecretaryMapping : IEntityTypeConfiguration<Secretary>
    {
        public void Configure(EntityTypeBuilder<Secretary> builder)
        {
            builder.ToTable("Secretaries");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FullName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.ContactNumber).IsRequired().HasMaxLength(15);


            builder.HasMany(s => s.DoctorSecretaries)
                .WithOne(s => s.Secretary)
                .HasForeignKey(s => s.SecretaryId);
        }
    }
}
