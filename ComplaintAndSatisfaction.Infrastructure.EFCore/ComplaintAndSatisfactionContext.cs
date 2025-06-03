using ComplaintAndSatisfaction.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ComplaintAndSatisfaction.Infrastructure.EFCore
{
    public class ComplaintAndSatisfactionContext : DbContext
    {
        public DbSet<ComplaintAndSatisfactionManagement.Domain.ComplaintAndSatisfactionAgg.ComplaintAndSatisfaction> ComplaintAndSatisfaction { get; set; }
        public ComplaintAndSatisfactionContext(DbContextOptions<ComplaintAndSatisfactionContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ComplaintAndSatisfactionMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}