using System.Collections.Generic;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using My_Shop_Framework.Application;
using Microsoft.Extensions.Logging;

namespace CommentManagement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ILogger<CommentApplication> _logger;

        public CommentApplication(ICommentRepository commentRepository, ILogger<CommentApplication> logger)
        {
            _commentRepository = commentRepository;
            _logger = logger;
        }

        public OperationResult CreateComment(CreateComment commend)
        {
            var operation = new OperationResult();
            if (!IsValidComment(commend))
                return operation.Failed("Invalid comment data");

            var comment = new Comment(commend.Name, commend.Email, commend.Phone, commend.Message, commend.OwnerId, commend.Type, commend.Subject);
            _commentRepository.Create(comment);
            _commentRepository.SaveChanges();

            _logger.LogInformation("Comment created successfully");

            return operation.Success();
        }

        public OperationResult Confirm(long id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.Get(id);
            if (comment == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);

            comment.Confirm();
            _commentRepository.SaveChanges();

            _logger.LogInformation("Comment confirmed successfully");

            return operation.Success();
        }

        public OperationResult Cancel(long id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.Get(id);
            if (comment == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);

            comment.Cancel();
            _commentRepository.SaveChanges();

            _logger.LogInformation("Comment cancelled successfully");

            return operation.Success();
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            _logger.LogInformation("Searching comments");
            return _commentRepository.Search(searchModel);
        }

        public List<CommentViewModel> MessageList()
        {
            _logger.LogInformation("Getting message list");
            return _commentRepository.MessageList();
        }

        private bool IsValidComment(CreateComment commend)
        {
            // Add your validation logic here
            return !string.IsNullOrWhiteSpace(commend.Name) &&
                   !string.IsNullOrWhiteSpace(commend.Email) &&
                   !string.IsNullOrWhiteSpace(commend.Message);
        }
    }
}
