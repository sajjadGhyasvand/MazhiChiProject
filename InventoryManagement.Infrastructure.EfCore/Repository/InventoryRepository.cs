using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.Inventory.Agg;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;
using ShopManagement.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;


namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class InventoryRepository:RepositoryBase<long,Inventory>,IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;
        public InventoryRepository( InventoryContext inventoryContext, ShopContext shopContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
        }

        public EditInventory GetDetails(long id)
        {
             return _inventoryContext.Inventory.Select(x => new EditInventory
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    UnitPrice = x.UnitPrice
                })
                .SingleOrDefault(x => x.Id == id);
        }

        public Inventory GetBy(long Id)
        {
            return _inventoryContext.Inventory.FirstOrDefault(x => x.Id == Id);
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                Id = x.Id,
                InStock = x.InStock,
                CurrentCount = x.CalculateCurrentCount()
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            if (searchModel.InStock)
                query = query.Where(x => !x.InStock);
            var inventory = query.OrderByDescending(x => x.Id).ToList();
            inventory.ForEach(item =>
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            });
            return inventory;
        }

        public List<InventoryOperationViewModel> GetInventoryOperationLog(long inventoryId)
        {
            var inventory = _inventoryContext.Inventory.FirstOrDefault(x => x.Id == inventoryId);
            return inventory.Operations.Select(x => new InventoryOperationViewModel
            {
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                OperationDate = x.OperationDate.ToFarsi(),
                Id = x.Id,
                Operation = x.Operation,
                OperatorId =x.OperatorId,
                Operator = "مدیر سیستم",
                CreationDate = x.OperationDate.ToFarsi()

            }).ToList();
        }
    }
}