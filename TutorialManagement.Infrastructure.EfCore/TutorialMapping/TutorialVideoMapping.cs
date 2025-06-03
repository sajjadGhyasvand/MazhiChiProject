using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorialManagement.Domain.TutorialVideo.Agg;

namespace TutorialManagement.Infrastructure.EfCore.TutorialMapping
{
    public class TutorialVideoMapping : IEntityTypeConfiguration<TutorialVideo>
    {
        public void Configure(EntityTypeBuilder<TutorialVideo> builder)
        {
            builder.ToTable("TutorialVideo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TitleFa).HasMaxLength(500).IsRequired();
            builder.Property(x => x.TitleEn).HasMaxLength(500).IsRequired();
            builder.Property(x => x.TitleRu).HasMaxLength(500).IsRequired();
            builder.Property(x => x.LinkAr).HasMaxLength(500).IsRequired();
            builder.Property(x => x.LinkFa).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.Poster).HasMaxLength(500).IsRequired();
            builder.Property(x => x.LinkAr).HasMaxLength(2000);
            builder.Property(x => x.LinkEn).HasMaxLength(2000);
            builder.Property(x => x.LinkRu).HasMaxLength(2000);
        }
    }
}