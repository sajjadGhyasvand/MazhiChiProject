using My_Shop_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;


namespace InventoryManagement.Domain.Inventory.Agg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }
        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }
        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }
        public long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Select(x => x.Count).Sum();
            var minus = Operations.Where(x => !x.Operation).Select(x => x.Count).Sum();
            return plus - minus;
        }

        public void Increase(long count, long operatorId, string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(true, count, operatorId, currentCount, description, 0, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
        public void Reduce(long count, long operatorId, string description, long orderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(false, count, operatorId, currentCount, description, orderId, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
    }

    public class InventoryOperation
    {
        public long Id { get; private set; }
        public bool Operation { get; private set; }
        public long Count { get; private set; }
        public long OperatorId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string Description { get; private set; }
        public long OrderId { get; private set; }
        public long InventoryId { get; private set; }
        public Inventory Inventory { get; private set; }

        public InventoryOperation(bool operation, long count, long operatorId, long currentCount, string description, long orderId, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
            InventoryId = inventoryId;
            OperationDate = DateTime.Now;
        }
    }
}