using BlogManagement.Domain.Articles.Agg;
using BlogManagement.Infrastructure.EFCore.Mapping;
using BlogManagement.Domain.ArticlePicture.Agg;
using BlogManagement.Domain.Articles.Agg;
using BlogManagement.Domain.ArticlesCategory.Agg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore
{
    public class BlogContext:DbContext
    {
    
        public DbSet<ArticlesCategory> ArticulateCategories { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<ArticlePicture> ArticlePictures { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticlesCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}