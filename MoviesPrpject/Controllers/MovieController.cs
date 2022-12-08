using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MoviesPrpject.Controllers
{
    
    public class MovieController : Controller
    {

        IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {

            var movies = movieService.GetAllMoviesWithCategories();
            return View(movies);
        }
        public IActionResult MovieDetails(int id)
        {
            ViewBag.id = id;
            var movie = movieService.GetAllMoviesWithCategoriesByMovieId(id);
            foreach (var item in movie.Data)
            {
                int writerId = item.WriterId;
                ViewBag.writerId = writerId;
                TempData["movieId"] = item.MovieId;

            }
            return View(movie);
        }

        public IActionResult MovieListByWriter(int id)
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = movieService.GetMovieListByWriterIdWithCategory(writerId);
            return View(values);
        }

        [HttpGet]
        public IActionResult MovieAdd()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());

            List<SelectListItem> categoryValues = (from x in cm.GetAllCategories().Data
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;

            return View();
        }

        [HttpPost]
        public IActionResult MovieAdd(Movie movie)
        {

            CategoryManager cm = new CategoryManager(new EfCategoryDal());

            List<SelectListItem> categoryValues = (from x in cm.GetAllCategories().Data
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;


            MovieValidationRules validationRules = new MovieValidationRules();
            ValidationResult results = validationRules.Validate(movie);
            if (results.IsValid)
            {
                Context c = new Context();
                movie.MovieStatus = true;
                movie.MovieCreateDate = DateTime.Now;
                var usermail = User.Identity.Name;
                var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
                movie.WriterId = writerId;
                movieService.AddMovie(movie);
                return RedirectToAction("MovieListByWriter", "Movie");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

        }

        public IActionResult DeleteMovie(int id)
        {
            var movie = movieService.GetMovieById(id);
            movieService.RemoveMovie(movie);
            return RedirectToAction("MovieListByWriter", "Movie");

        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryValues = (from c in cm.GetAllCategories().Data

                                                   select new SelectListItem
                                                   {
                                                       Text = c.CategoryName,
                                                       Value = c.CategoryId.ToString(),
                                                   }
                                                   ).ToList();
            ViewBag.values = categoryValues;
            var movie = movieService.GetMovieById(id);
            TempData["date"] = movie.MovieCreateDate;
            TempData["status"] = movie.MovieStatus;
            TempData["writerIdForUpdate"] = movie.WriterId;
            return View(movie);
        }

        [HttpPost]              //status ve writer ıd bak
        public IActionResult EditMovie(Movie movie)
        {
            movie.WriterId = (int)TempData["writerIdForUpdate"];
            movie.MovieStatus = (bool)TempData["status"];
            movie.MovieCreateDate = (DateTime)TempData["date"];
            movieService.UpdateMovie(movie);
            return RedirectToAction("MovieListByWriter", "Movie");
        }
    }
}
