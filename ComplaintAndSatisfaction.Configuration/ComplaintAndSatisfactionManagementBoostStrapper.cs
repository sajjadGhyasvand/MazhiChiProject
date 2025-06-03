using CommentManagement.Infrastructure.EFCore;
using ComplaintAndSatisfaction.Application;
using ComplaintAndSatisfaction.Application.Contract.ComplaintAndSatisfaction;
using ComplaintAndSatisfaction.Infrastructure.EFCore;
using ComplaintAndSatisfaction.Infrastructure.EFCore.Repository;
using ComplaintAndSatisfactionManagement.Domain.ComplaintAndSatisfactionAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ComplaintAndSatisfaction.Configuration
{
    public class ComplaintAndSatisfactionManagementBoostStrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {

            service.AddTransient<IComplaintAndSatisfactionRepository, ComplaintAndSatisfactionRepository>();
            service.AddTransient<IComplaintAndSatisfactionApplication, ComplaintAndSatisfactionApplication>();


            service.AddDbContext<ComplaintAndSatisfactionContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
