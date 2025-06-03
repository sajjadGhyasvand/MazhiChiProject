using Microsoft.EntityFrameworkCore;
using TutorialManagement.Domain.IntroductionVideo.Agg;
using TutorialManagement.Domain.TutorialVideo.Agg;
using TutorialManagement.Infrastructure.EfCore.TutorialMapping;

namespace TutorialManagement.Infrastructure.EfCore
{
    public class TutorialContext : DbContext
    {
        public DbSet<IntroductionVideo> IntroductionVideos { get; set; }
        public DbSet<TutorialVideo> TutorialVideos { get; set; }
        public DbSet<VideoView> VideoViews { get; set; }


        public TutorialContext(DbContextOptions<TutorialContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(TutorialVideoMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}