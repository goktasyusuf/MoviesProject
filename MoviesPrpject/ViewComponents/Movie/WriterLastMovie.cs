using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.ViewComponents.Movie
{
    public class WriterLastMovie : ViewComponent
    {
        IMovieService movieService;

        public WriterLastMovie(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = movieService.GetMovieListByWriterId(writerId);
            return View(values);
        }
    }
}
