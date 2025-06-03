using System.Collections.Generic;
using My_Shop_Framework.Application;


namespace TutorialManagement.Application.Contract.IntroductionVideo
{
    public interface IIntroductionVideoApplication
    {
        OperationResult Create(CreateIntroductionVideo command);
        OperationResult Edit(EditIntroductionVideo command);
        EditIntroductionVideo GetDetails(long id);
        List<IntroductionVideoViewModel> List();
    }
}