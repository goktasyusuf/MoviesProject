using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.Controllers
{
    public class CategoryController : Controller
    {

        ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var results = categoryService.GetAllCategories();
            return View(results);
        }
    }
}
