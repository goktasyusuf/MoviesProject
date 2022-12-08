using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Business.ValidationRules.FluentValidation;
using FluentValidation.Results;

namespace MoviesPrpject.Controllers
{
    public class WriterController : Controller
    {
        IWriterService writerService;

        public WriterController(IWriterService writerService)
        {
            this.writerService = writerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult EditWriterProfile()
        {
            var writer = writerService.GetWriterByWriterId2(1);
            return View(writer);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult EditWriterProfile(Writer writer)
        {
            WriterValidationRules vl = new WriterValidationRules();
            ValidationResult results = vl.Validate(writer);

            if(results.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterId = 1;
                writerService.UpdateWriter(writer); 
                return RedirectToAction("Index", "Dashboard");
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
    }
}
