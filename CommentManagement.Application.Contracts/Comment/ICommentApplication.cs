using System.Collections.Generic;
using My_Shop_Framework.Application;

namespace CommentManagement.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        OperationResult CreateComment(CreateComment commend);
        OperationResult Confirm(long id);
        OperationResult Cancel(long id);
        List<CommentViewModel> Search(CommentSearchModel searchModel);
        // List<CommentViewModel> ByType(int type);
        List<CommentViewModel> MessageList();
    }
}