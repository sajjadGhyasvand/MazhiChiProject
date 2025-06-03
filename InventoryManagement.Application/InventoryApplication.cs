
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.Inventory.Agg;
using My_Shop_Framework.Application;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public  class InventoryApplication:IInventoryApplication
   {
       private readonly IInventoryRepository _inventoryRepository;

       public InventoryApplication(IInventoryRepository inventoryRepository)
       {
           _inventoryRepository = inventoryRepository;
       }

       public OperationResult Create(CreateInventory command)
       {
           var operation = new OperationResult();
           if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId))
               return operation.Failed(ApplicationMessages.DuplicatedRecord);
           var inventory = new Inventory(command.ProductId, command.UnitPrice);
           _inventoryRepository.Create(inventory);
           _inventoryRepository.SaveChanges();
           return operation.Success();
       }

        public OperationResult Edit(EditInventory command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.Get(command.Id);
            
            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            inventory.Edit(command.ProductId, command.UnitPrice);
            _inventoryRepository.SaveChanges();
            return operation.Success();
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryRepository.GetDetails(id);
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            return _inventoryRepository.GetInventoryOperationLog(inventoryId);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            const long operatorId = 1;
            var operation = new OperationResult();
            var inventory = _inventoryRepository.GetBy(command.InventoryId);
            if (inventory == null)
                operation.Failed(ApplicationMessages.RecordNotFund);
            if (inventory != null) inventory.Increase(command.Count, operatorId, command.Description);
            _inventoryRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Reduce(ReduceInventory command)
        {
            const long operatorId = 1;
            var operation = new OperationResult();
            var inventory = _inventoryRepository.GetBy(command.InventoryId);
            if (inventory == null)
                operation.Failed(ApplicationMessages.RecordNotFund);
            if (inventory != null) inventory.Reduce(command.Count, operatorId, command.Description,0);
            _inventoryRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Reduce(List<ReduceInventory> command)
        {
            var operation = new OperationResult();
            const long operatorId = 1;
            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetBy(item.InventoryId);
                if (inventory != null) inventory.Reduce(item.Count, operatorId, item.Description, 0);
            }
            _inventoryRepository.SaveChanges();
           return operation.Success();
        }
    }
}
