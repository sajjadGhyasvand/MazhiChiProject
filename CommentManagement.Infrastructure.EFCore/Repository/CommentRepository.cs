using System.Collections.Generic;
using System.Linq;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;

namespace CommentManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _commentContext;

        public CommentRepository(CommentContext commentContext) : base(commentContext)
        {
            _commentContext = commentContext;
        }


        public List<CommentViewModel> Search(CommentSearchModel commend)
        {
            var query = _commentContext.Comments.Select(x => new CommentViewModel
            {
                Email = x.Email,
                IsCancel = x.IsCancel,
                IsConfirmed = x.IsConfirmed,
                Message = x.Message,
                Name = x.Name,
                Phone = x.Phone,
                CommentDate = x.CreationDateTime.ToFarsi(),
                Date = x.CreationDateTime,
                Id = x.Id,
                OwnerId = x.OwnerId,
                OwnerName = x.Name,
                Type = x.Type,
                IsActive = x.IsActive,
                
            });
            if (!string.IsNullOrWhiteSpace(commend.Name))
                query = query.Where(x => x.Name.Contains(commend.Name));
            if (!string.IsNullOrWhiteSpace(commend.Email))
                query = query.Where(x => x.Name.Contains(commend.Email));

            return query.OrderByDescending(x => x.Id).Where(x => x.Type != CommentType.Message).ToList();
        }

        public List<CommentViewModel> MessageList()
        {
            var query = _commentContext.Comments.Select(x => new CommentViewModel
            {
                Email = x.Email,
                IsCancel = x.IsCancel,
                IsConfirmed = x.IsConfirmed,
                Message = x.Message,
                Name = x.Name,
                Phone = x.Phone,
                CommentDate = x.CreationDateTime.ToFarsi(),
                Date = x.CreationDateTime,
                Id = x.Id,
                OwnerId = x.OwnerId,
                OwnerName = x.Name,
                Type = x.Type
            });
            return query.OrderByDescending(x => x.Id).Where(x => x.Type == CommentType.Message).ToList();
        }

        //public List<CommentViewModel> ByType(int type)
        //{
        //    var query = _commentContext.Comments.Select(x => new CommentViewModel
        //    {
        //        Email = x.Email,
        //        IsCancel = x.IsCancel,
        //        IsConfirmed = x.IsConfirmed,
        //        Message = x.Message,
        //        Name = x.Name,
        //        Phone = x.Phone,
        //        CommentDate = x.CreationDateTime.ToFarsi(),
        //        Date = x.CreationDateTime,
        //        Id = x.Id,
        //        OwnerId = x.OwnerId,
        //        OwnerName = x.Name,
        //        Type = x.Type
        //    });
        //    if (query.Any())
        //        return query.Where(x => x.Type == type).OrderByDescending(x => x.Id).ToList();
        //    return new List<CommentViewModel>();
        //}
    }
}