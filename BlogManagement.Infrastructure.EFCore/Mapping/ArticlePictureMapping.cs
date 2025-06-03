using BlogManagement.Domain.ArticlePicture.Agg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticlePictureMapping : IEntityTypeConfiguration<ArticlePicture>
    {
        public void Configure(EntityTypeBuilder<ArticlePicture> builder)
        {
            builder.ToTable("ArticlePictures");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.HasOne(x => x.Article).WithMany(x => x.ArticlePictures).HasForeignKey(x => x.ArticleId);

        }
    }
}