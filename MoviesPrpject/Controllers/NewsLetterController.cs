using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.Controllers
{
    public class NewsLetterController : Controller
    {

        INewsLetterService _newsletterService;

        public NewsLetterController(INewsLetterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            _newsletterService.AddNewsLetter(newsLetter);
            Thread.Sleep(3000);
            return RedirectToAction("Index", "Movie");
            //return PartialView();
        }
    }
}
