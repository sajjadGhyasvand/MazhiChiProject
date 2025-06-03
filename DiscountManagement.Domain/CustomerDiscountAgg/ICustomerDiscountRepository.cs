using DiscountManagement.Application.Contracts.CustomerDiscount;
using My_Shop_Framework.Domain;
using System.Collections.Generic;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository:IRepository<long ,CustomerDiscount>
    {
        EditCustomerDiscount GetDetails(long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
    }
}