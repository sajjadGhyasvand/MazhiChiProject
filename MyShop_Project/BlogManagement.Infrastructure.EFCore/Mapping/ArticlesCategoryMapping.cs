using BlogManagement.Domain.ArticlesCategory.Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticlesCategoryMapping : IEntityTypeConfiguration<ArticlesCategory>
    {
        public void Configure(EntityTypeBuilder<ArticlesCategory> builder)
        {
            builder.ToTable("ArticulateCategories");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(3000);
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(250);
            builder.Property(x => x.PictureTitle).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Keywords).IsRequired().HasMaxLength(100);
            builder.Property(x => x.MetaDescription).IsRequired().HasMaxLength(150);

            builder.HasMany(x => x.Articles).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}