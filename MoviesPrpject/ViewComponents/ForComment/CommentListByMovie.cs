using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.ViewComponents.Comment
{
    public class CommentListByMovie : ViewComponent
    {
        ICommentService commentService;

        public CommentListByMovie(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = commentService.GetComments(id);
            return View(values);
        }
    }
}
