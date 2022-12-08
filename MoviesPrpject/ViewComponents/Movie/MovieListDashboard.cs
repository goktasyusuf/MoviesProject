using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.ViewComponents.Movie
{
    public class MovieListDashboard:ViewComponent
    {
        IMovieService movieService;

        public MovieListDashboard(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            //var values = movieService.GetAllMoviesWithCategories();
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = movieService.GetMovieListByWriterIdWithCategory(writerId);
            return View(values);
        }
    }
}
