using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MoviesPrpject.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		
		[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {
			Context c = new Context();
			var isTrue = c.Writers.SingleOrDefault(w => w.WriterMail == writer.WriterMail && w.WriterPassword == writer.WriterPassword);
			if(isTrue!=null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name , writer.WriterMail)
				};
				var userIdentity = new ClaimsIdentity(claims ,"a");
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
                return View();
            }
            
        }
    }
}
