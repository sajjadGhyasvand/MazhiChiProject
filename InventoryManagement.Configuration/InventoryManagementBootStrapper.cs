

using InventoryManagement.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Configuration.Permissions;
using InventoryManagement.Domain.Inventory.Agg;
using InventoryManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My_Shop_Framework.Infrastructure;

namespace InventoryManagement.Configuration
{
    public class InventoryManagementBootStrapper
    {
        public static void Configure(IServiceCollection service,string connectionString)
        {
            service.AddTransient<IInventoryRepository, InventoryRepository>();
            service.AddTransient<IInventoryApplication, InventoryApplication>();

            service.AddTransient<IPermissionsExpose, InventoryPermissionExpose>();

            service.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
