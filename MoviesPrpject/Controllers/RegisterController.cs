using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesPrpject.Models;

namespace MoviesPrpject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        IWriterService movieWriterService;

        public RegisterController(IWriterService movieWriterService)
        {
            this.movieWriterService = movieWriterService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            if (writer.WriterPassword == null)
            {
                return View();
            }
            WriterValidationRules validationRules = new WriterValidationRules();
            ValidationResult results = validationRules.Validate(writer);

            
            if (results.IsValid)
            {
                writer.WriterStatus = true;
                movieWriterService.AddMovieWriter(writer);
                return RedirectToAction("Index", "Movie");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }

    }
}
