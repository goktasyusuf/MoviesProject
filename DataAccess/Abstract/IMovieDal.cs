using Core.DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMovieDal : IEntityRepositoryBase<Movie>
    {
        List<Movie> GetAllMoviesWithCategories();
       public  List<Movie> GetMovieListByWriterIdWithCategory(int writerId);
        List<Movie> GetMoviesWithCategoriesByMovieId(int movieId);
    }
}
