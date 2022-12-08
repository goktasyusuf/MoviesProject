using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.ViewComponents.Writer
{
    public class WriterMessageNotification :ViewComponent
    {

        public IViewComponentResult Invoke(int id)
        {

            return View();
        }

    }
}
