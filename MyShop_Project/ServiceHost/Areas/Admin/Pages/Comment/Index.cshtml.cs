using System.Collections.Generic;
using CommentManagement.Application.Contracts.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Comment
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly ICommentApplication _commentApplication;
        public List<CommentViewModel> CommentViewModels;
        public CommentSearchModel SearchModel;
      
        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet(CommentSearchModel searchModel) 
        {
            CommentViewModels = _commentApplication.Search(searchModel);
        }

        public IActionResult OnGetCancel(long id)
        {
            var result = _commentApplication.Cancel(id);
            if (result.IsSuccess)
                return RedirectToPage("./Index");
            Message = result.Massage;
            return RedirectToPage("./Index");


        }
        public IActionResult OnGetConfirm(long id)
        {
            var result = _commentApplication.Confirm(id);
            if (result.IsSuccess)
                return RedirectToPage("./Index");
            Message = result.Massage;
            return RedirectToPage("./Index");
        }
    }
}
