using System.Collections.Generic;
using CommentManagement.Application.Contracts.Comment;
using My_Shop_Framework.Domain;

namespace CommentManagement.Domain.CommentAgg
{
    public interface ICommentRepository:IRepository<long ,Comment>
    {
        List<CommentViewModel> Search(CommentSearchModel commend);
        List<CommentViewModel> MessageList();
    }
}