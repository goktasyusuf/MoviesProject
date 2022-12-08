using Business.Abstract;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public IResult AddCategory(Category category)
        {
            categoryDal.Add(category);
            return new SuccessResult("Kategori eklendi");
        }

        public IDataResult<List<Category>> GetAllCategories()
        {
            return new SuccessDataResult<List<Category>>(categoryDal.GetAll(), "Kategoriler getirildi");
        }

        public IDataResult<Category> GetCategoryById(int id)
        {
            return new SuccessDataResult<Category>(categoryDal.Get(c => c.CategoryId == id), $"{id} ye sahip kategori getirildi");
        }

        public IResult RemoveCategory(Category category)
        {
            categoryDal.Delete(category);
            return new SuccessResult("Kategori silindi");
        }

        public IResult UpdateCategory(Category category)
        {
            categoryDal.Update(category);
            return new SuccessResult("Kategori güncellendi");
        }
    }
}
