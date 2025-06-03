using My_Shop_Framework.Application;
using System.Collections.Generic;

namespace DiscountManagement.Application.Contracts.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Create(CreateColleagueDiscount commend);
        OperationResult Edit(EditColleagueDiscount commend);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditColleagueDiscount GetDetails(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
        
    }
}