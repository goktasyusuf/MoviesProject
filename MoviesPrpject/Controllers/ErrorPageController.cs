using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Error1(int code)
		{
			return View();
		}
	}
}
