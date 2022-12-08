using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.Controllers
{
    public class DashboardController : Controller
    {      
        public IActionResult Index()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            
            ViewBag.all = c.Movies.Count().ToString();
            ViewBag.your = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.Movies).Count();
            ViewBag.allC = c.Categories.Count();
            return View();
        }
    }
}
