
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;
using ShopManagement.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;


namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository:RepositoryBase<long,CustomerDiscount>,ICustomerDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly ShopContext _shopContext;
        public CustomerDiscountRepository(DiscountContext discountContext,ShopContext shopContext):base(discountContext)
        {
            _discountContext = discountContext;
            _shopContext = shopContext;
        }
        public EditCustomerDiscount GetDetails(long id)
        {
            return _discountContext.CustomerDiscounts.Select(x => new EditCustomerDiscount
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                EndDate = x.EndDate.ToFarsi(),
                StartDate = x.StartDate.ToFarsi(),
                ProductId = x.ProductId,
                Reason = x.Reason
            }).SingleOrDefault(x => x.Id == id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query= _discountContext.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi(),
                StartDateGr = x.StartDate,
                EndDateGr = x.EndDate,
                ProductId = x.ProductId,
                Reason = x.Reason
            });

             if (searchModel.ProductId > 0)
                 query =query.Where(x => x.ProductId == searchModel.ProductId);

             
             if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
             {
                 var test = searchModel.StartDate.ToGeorgianDateTime();
                query = query.Where(x => x.StartDateGr < test);
             }
             if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
             {
                 var test = searchModel.EndDate.ToGeorgianDateTime();
                 query = query.Where(x => x.EndDateGr > test);
             }

             var discounts = query.OrderByDescending(x => x.Id).ToList();
             discounts.ForEach(discount => discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
            return discounts;
        }

    }
}