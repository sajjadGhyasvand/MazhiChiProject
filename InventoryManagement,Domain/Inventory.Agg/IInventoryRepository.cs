
using InventoryManagement.Application.Contract.Inventory;
using My_Shop_Framework.Domain;
using System.Collections.Generic;

namespace InventoryManagement.Domain.Inventory.Agg
{
    public interface IInventoryRepository:IRepository<long,Inventory>
    {
        EditInventory GetDetails(long id);
        Inventory GetBy(long productId);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetInventoryOperationLog(long inventoryId);
    }
}