using EventManagement.Domain.Event.Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagement.Infrastructure.EFCore.Mapping
{
    public class EventMapping:IEntityTypeConfiguration<Events>
    {
        public void Configure(EntityTypeBuilder<Events> builder)
        {
            builder.ToTable("Events");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(550);
            builder.Property(x => x.ShortDescription).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PictureTitle).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Keywords).IsRequired().HasMaxLength(80);
            builder.Property(x => x.MetDescription).IsRequired().HasMaxLength(150);
        }
    }
}