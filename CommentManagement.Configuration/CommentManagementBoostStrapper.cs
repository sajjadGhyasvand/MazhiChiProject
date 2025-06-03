
using CommentManagement.Application;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EFCore;
using CommentManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My_ShopQuery.Contract.Comment;
using My_ShopQuery.Query;

namespace CommentManagement.Configuration
{
    public class CommentManagementBoostStrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {

            service.AddTransient<ICommentRepository, CommentRepository>();
            service.AddTransient<ICommentApplication, CommentApplication>();

            service.AddTransient<ICommentQueryModel, CommentQuery>();

            service.AddDbContext<CommentContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
