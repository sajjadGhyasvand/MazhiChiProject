using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My_ShopQuery.Contract.Video;
using My_ShopQuery.Query;
using TutorialManagement.Application;
using TutorialManagement.Application.Contract.IntroductionVideo;
using TutorialManagement.Application.Contract.TutorialVideo;
using TutorialManagement.Domain.IntroductionVideo.Agg;
using TutorialManagement.Domain.TutorialVideo.Agg;
using TutorialManagement.Infrastructure.EfCore;
using TutorialManagement.Infrastructure.EfCore.Repository;

namespace TutorialManagement.Configuration
{
    public class TutorialBoostStrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
           

            service.AddTransient<ITutorialVideoRepository, TutorialVideoRepository>();
            service.AddTransient<ITutorialVideoApplication, TutorialVideoApplication>();
            service.AddTransient<IIntroductionVideoRepository, IntroductionVideoRepository>();
            service.AddTransient<IIntroductionVideoApplication, IntroductionVideoApplication>();


            service.AddTransient<IVideoQueryModel, VideoQueryModel>();

            service.AddDbContext<TutorialContext>(x => x.UseSqlServer(connectionString));
        }
    }
}