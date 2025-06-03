using My_Shop_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class CreateCustomerDiscount
    {
        [Range(1, 100000000000000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }
        [Range(1, 99, ErrorMessage = ValidationMessages.IsRequired)]
        public int DiscountRate { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string StartDate { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string EndDate { get; set; }
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string Reason { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}