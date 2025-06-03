using BlogManagement.Domain.Articles.Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticlesMapping:IEntityTypeConfiguration<Articles>
    {
        public void Configure(EntityTypeBuilder<Articles> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(550);
            builder.Property(x => x.ShortDescription).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PictureTitle).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Keywords).IsRequired().HasMaxLength(80);
            builder.Property(x => x.MetDescription).IsRequired().HasMaxLength(150);

            builder.HasOne(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId);


        }
    }
}