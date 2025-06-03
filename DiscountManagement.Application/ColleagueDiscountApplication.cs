
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using My_Shop_Framework.Application;
using System.Collections.Generic;
namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Create(CreateColleagueDiscount commend)
        {
            var operation = new OperationResult();
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == commend.ProductId && x.DiscountRate == commend.DiscountRate))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var colleagueDiscount = new ColleagueDiscount(commend.ProductId, commend.DiscountRate);
            _colleagueDiscountRepository.Create(colleagueDiscount);
            _colleagueDiscountRepository.SaveChanges();

            return operation.Success();
        }

        public OperationResult Edit(EditColleagueDiscount commend)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(commend.Id);
            if (colleagueDiscount == null)
                operation.Failed(ApplicationMessages.RecordNotFund);
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == commend.ProductId && x.DiscountRate == commend.DiscountRate))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            colleagueDiscount.Edit(commend.ProductId, commend.DiscountRate);
            _colleagueDiscountRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            if (colleagueDiscount == null)
                operation.Failed(ApplicationMessages.RecordNotFund);
            colleagueDiscount.Remove();
            _colleagueDiscountRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            if (colleagueDiscount == null)
                operation.Failed(ApplicationMessages.RecordNotFund);
            colleagueDiscount.Restore();
            _colleagueDiscountRepository.SaveChanges();
            return operation.Success();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _colleagueDiscountRepository.Search(searchModel);
        }
    }
}