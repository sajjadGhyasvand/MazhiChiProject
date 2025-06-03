using EventManagement.Application;
using EventManagement.Application.Contracts.Events;
using EventManagement.Application.Contracts.EventsPicture;
using EventManagement.Domain.Event.Agg;
using EventManagement.Domain.EventPicture;
using EventManagement.Infrastructure.EFCore;
using EventManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My_ShopQuery.Contract.Events;
using My_ShopQuery.Query;

namespace EventManagement.Configuration
{
    public class EventManagementBootStrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {

            service.AddTransient<IEventRepository, EventsRepository>();
            service.AddTransient<IEventApplication, EventApplication>();

            service.AddTransient<IEventPictureRepository, EventsPictureRepository>();
            service.AddTransient<IEventsPictureApplication, EventsApplication>();

            service.AddTransient<IEventsQueryModel, EventsQuery>();


            service.AddDbContext<EventContext>(x => x.UseSqlServer(connectionString));

        }
    }
}