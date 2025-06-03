using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplaintAndSatisfaction.Infrastructure.EFCore.Mapping
{
    public class ComplaintAndSatisfactionMapping:IEntityTypeConfiguration<ComplaintAndSatisfactionManagement.Domain.ComplaintAndSatisfactionAgg.ComplaintAndSatisfaction>
    {
        public void Configure(EntityTypeBuilder<ComplaintAndSatisfactionManagement.Domain.ComplaintAndSatisfactionAgg.ComplaintAndSatisfaction> builder)
        {
            object value = builder.ToTable("ComplaintAndSatisfaction");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Mobile).IsRequired().HasMaxLength(30);
            builder.Property(x => x.PhoneNumber).HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Message).IsRequired().HasMaxLength(2000);

        }
    }
}