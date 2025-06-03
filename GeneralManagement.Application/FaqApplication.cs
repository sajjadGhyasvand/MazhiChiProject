using System.Collections.Generic;
using GeneralManagement.Application.Contracts.Faq;
using GeneralManagement.Domain.FaqAgg;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application
{
    public class FaqApplication: IFaqApplication
    {

        private  readonly  IFaqRepository _faqRepository;

        public FaqApplication(IFaqRepository faqRepository)
        {
            this._faqRepository = faqRepository;
        }

        public OperationResult Create(CreateFaq command)
        {
            var operation = new OperationResult();

            if (_faqRepository.Exists(x => x.Question == command.Question && x.LanguageId != command.LanguageId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
          
            var faq = new Faq(command.Question, command.Answer, command.LanguageId);
            _faqRepository.Create(faq);
            _faqRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditFaq command)
        {
            var operation = new OperationResult();
            var faq = _faqRepository.Get(command.Id);
            if (faq == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            if (_faqRepository.Exists(x => x.Question == command.Question && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            faq.Edit(command.Question, command.Answer
                ,command.LanguageId);
            _faqRepository.SaveChanges();
            return operation.Success();
        }

        public EditFaq GetDetails(long id)
        {
            return _faqRepository.GetDetails(id);
        }

        public List<FaqViewModel> GetList()
        {
            return _faqRepository.GetList();
        }

        public OperationResult IsRemove(long id)
        {
            var operation = new OperationResult();
            var faq = _faqRepository.Get(id);
            if (faq == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            faq.Remove();
            _faqRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var faq = _faqRepository.Get(id);
            if (faq == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            faq.Restore();
            _faqRepository.SaveChanges();
            return operation.Success();
        }
    }
}