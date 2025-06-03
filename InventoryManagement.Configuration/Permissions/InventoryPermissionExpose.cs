using System.Collections.Generic;
using My_Shop_Framework.Infrastructure;

namespace InventoryManagement.Configuration.Permissions
{
    public class InventoryPermissionExpose:IPermissionsExpose
    {
        public Dictionary<string, List<PermissionsDto>> Expose()
        {
            return new Dictionary<string, List<PermissionsDto>>
            {
                {
                    "Inventory",new List<PermissionsDto>
                    {
                        new PermissionsDto(InventoryPermission.CreateCode,InventoryPermission.CreateName),
                        new PermissionsDto(InventoryPermission.EditCode,InventoryPermission.EditName),
                        new PermissionsDto(InventoryPermission.GetOperationLogCode,InventoryPermission.GetOperationLogName),
                        new PermissionsDto(InventoryPermission.IncreaseCode,InventoryPermission.IncreaseName),
                        new PermissionsDto(InventoryPermission.ReduceCode,InventoryPermission.ReduceName),
                    }
                }
            };
        }
    }
}