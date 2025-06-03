using System.ComponentModel.DataAnnotations;
using My_Shop_Framework.Application;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class IncreaseInventory

    {
        public long  InventoryId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long  Count { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(1000,ErrorMessage = "تعداد کاراکتر {0} می باشد")]
        public string Description  { get; set; }

    }
}