using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        IWriterService writerService;

        public WriterAboutOnDashboard(IWriterService writerService)
        {
            this.writerService = writerService;
        }

        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = writerService.GetWriterByWriterId(writerId); 
            return View(values);

        }
    }
}
