using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.Controllers
{
	[AllowAnonymous]
	public class AboutController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}
	}
}
