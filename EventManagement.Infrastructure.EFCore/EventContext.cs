using EventManagement.Domain.Event.Agg;
using EventManagement.Domain.EventPicture;
using EventManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Infrastructure.EFCore
{
    public class EventContext:DbContext
    {
    
        public DbSet<Events> Events { get; set; }
        public DbSet<EventPicture> EventPictures { get; set; }


        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(EventMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}