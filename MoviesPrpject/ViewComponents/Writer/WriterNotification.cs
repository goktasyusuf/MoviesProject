using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.ViewComponents.Writer
{
    public class WriterNotification :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
