namespace InventoryManagement.Configuration.Permissions
{
    public static class InventoryPermission
    {
        //Inventory
        public const long CreateCode = 50;
        public const string CreateName = "ایجاد انبار";

        public const long EditCode = 51;
        public const string EditName = "ویرایش انبار";

        public const long GetOperationLogCode = 52;
        public const string GetOperationLogName = "گزارش  انبار";

        public const long IncreaseCode = 53;
        public const string IncreaseName = "افزایش موجودی انبار";

        public const long ReduceCode = 54;
        public const string ReduceName = "کاهش موجودی انبار";


    }
}
