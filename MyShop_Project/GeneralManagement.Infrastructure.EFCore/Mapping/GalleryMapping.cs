using GeneralManagement.Domain.FaqAgg;
using GeneralManagement.Domain.GalleryAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GeneralManagement.Infrastructure.EFCore.Mapping
{
    public class GalleryMapping : IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            builder.ToTable("Gallery");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(800);
            builder.Property(x => x.PictureTitle).IsRequired().HasMaxLength(800);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(400);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(4000);
        }
    }
}