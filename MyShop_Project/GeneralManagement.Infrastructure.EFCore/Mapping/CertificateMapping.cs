using GeneralManagement.Domain.AboutAgg;
using GeneralManagement.Domain.CertificateAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GeneralManagement.Infrastructure.EFCore.Mapping
{
    public class CertificateMapping : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.ToTable("Certificate");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Description).IsRequired();
        }
    }
}