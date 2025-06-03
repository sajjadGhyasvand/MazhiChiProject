using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Infrastructure.EFCore;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;
using ShopManagement.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;


namespace CustomerDiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _colleagueDiscountContext;
        private readonly ShopContext _shopContext;

        public ColleagueDiscountRepository(DiscountContext discountContext, ShopContext shopContext) : base(discountContext)
        {
            _colleagueDiscountContext = discountContext;
            _shopContext = shopContext;
        }


        public EditColleagueDiscount GetDetails(long id)
        {
            return _colleagueDiscountContext.ColleagueDiscount.Select(x => new EditColleagueDiscount
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId,
            })
                .SingleOrDefault(x => x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _colleagueDiscountContext.ColleagueDiscount.Select(x => new ColleagueDiscountViewModel
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId,
                CreationDateTime = x.CreationDateTime.ToFarsi(),
                IsRemove = x.IsRemove
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            var discount = query.OrderByDescending(x => x.Id).ToList();
            discount.ForEach(discount => discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
            return discount;
        }
    }
}