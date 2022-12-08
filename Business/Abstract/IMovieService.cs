using Core.Utilites.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieService
    {

        IResult AddMovie(Movie movie);
        IResult RemoveMovie(Movie movie);
        void UpdateMovie(Movie movie);
        IDataResult<List<Movie>> GetAllMovies();
        Movie GetMovieById(int id);
        IDataResult<List<Movie>> GetMoviesByCategoryId(int id);
        IDataResult<List<Movie>> GetAllMoviesWithCategories();
        IDataResult<List<Movie>> GetAllMoviesWithCategoriesByMovieId(int movieId);
        IDataResult<List<Movie>> GetMovieListByWriterId(int id);
        IDataResult<List<Movie>> GetMovieListByWriterIdWithCategory(int writerId);

    }
}
