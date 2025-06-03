using EventManagement.Domain.EventPicture;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Infrastructure.EFCore.Mapping
{
    public class EventsPictureMapping : IEntityTypeConfiguration<EventPicture>
    {
        public void Configure(EntityTypeBuilder<EventPicture> builder)
        {
            builder.ToTable("EventPicturePictures");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.HasOne(x => x.Events).WithMany(x => x.EventPictures).HasForeignKey(x => x.EventId);

        }
    }
}