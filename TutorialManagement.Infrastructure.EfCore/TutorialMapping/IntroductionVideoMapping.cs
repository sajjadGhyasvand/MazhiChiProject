using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorialManagement.Domain.IntroductionVideo.Agg;

namespace TutorialManagement.Infrastructure.EfCore.TutorialMapping
{
    public class IntroductionVideoMapping : IEntityTypeConfiguration<IntroductionVideo>
    {
        public void Configure(EntityTypeBuilder<IntroductionVideo> builder)
        {
            builder.ToTable("IntroductionVideo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Link).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.Poster).HasMaxLength(500).IsRequired();
            builder.Property(x => x.LanguageId).IsRequired();
        }
    }
}