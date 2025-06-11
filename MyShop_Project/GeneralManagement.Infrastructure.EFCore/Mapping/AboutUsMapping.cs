using GeneralManagement.Domain.AboutAgg;
using GeneralManagement.Domain.GeneralAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GeneralManagement.Infrastructure.EFCore.Mapping
{
    public class AboutUsMapping : IEntityTypeConfiguration<AboutUs>
    {
        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            builder.ToTable("AboutUs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.ShortDescription).IsRequired().HasMaxLength(5000);

        }
    }
    
}