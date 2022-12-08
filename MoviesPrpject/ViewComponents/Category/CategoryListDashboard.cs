using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        ICategoryService categoryService;

        public CategoryListDashboard(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        public IViewComponentResult Invoke()
        {
            var values = categoryService.GetAllCategories();
            return View(values);

        }
    }
}
