using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPrpject.ViewComponents.Category
{
	public class CategoryList:ViewComponent
	{
		ICategoryService categoryService;

		public CategoryList(ICategoryService categoryService)
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
