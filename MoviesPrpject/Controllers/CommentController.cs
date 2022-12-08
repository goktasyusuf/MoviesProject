using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entity.Concrete;

namespace MoviesPrpject.Controllers
{
    public class CommentController : Controller
    {

        ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment comment)
        {
            comment.CommentStatus = true;
            comment.MovieId = (int)TempData["movieId"];
            //comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentDate = DateTime.Now;
            commentService.AddComment(comment);
            Thread.Sleep(3000);
            return RedirectToAction("Index", "Movie");
            //return RedirectToAction("MovieDetails", "Movie" , comment.MovieId);
        }

        public IActionResult ListCommentsByMovie(int id)
        {
            var values = commentService.GetComments(id);
            return PartialView(values);
        }
    }
}
