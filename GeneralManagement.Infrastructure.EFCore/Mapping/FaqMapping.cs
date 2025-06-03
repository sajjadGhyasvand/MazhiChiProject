using GeneralManagement.Domain.AboutAgg;
using GeneralManagement.Domain.FaqAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GeneralManagement.Infrastructure.EFCore.Mapping
{
    public class FaqMapping : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.ToTable("Faq");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Answer).IsRequired().HasMaxLength(800);
            builder.Property(x => x.Question).IsRequired().HasMaxLength(4000);
        }
    }
    
}