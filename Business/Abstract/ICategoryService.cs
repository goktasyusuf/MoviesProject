using Core.Utilites.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {

        IResult AddCategory(Category category);
        IResult RemoveCategory(Category category);
        IResult UpdateCategory(Category category);
        IDataResult<List<Category>> GetAllCategories();
        IDataResult<Category> GetCategoryById(int id);
    }
}
