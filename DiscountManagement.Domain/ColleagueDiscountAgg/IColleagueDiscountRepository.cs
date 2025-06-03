using DiscountManagement.Application.Contracts.ColleagueDiscount;
using My_Shop_Framework.Domain;
using System.Collections.Generic;


namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository:IRepository<long,ColleagueDiscount>
    {
        EditColleagueDiscount GetDetails(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
    }
}