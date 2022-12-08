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
    public class MovieManager :IMovieService
    {

        IMovieDal movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            this.movieDal = movieDal;
        }

        public IResult AddMovie(Movie movie)
        {
            movieDal.Add(movie);
            return new SuccessResult("Film eklendi");
        }

        public IDataResult<List<Movie>> GetAllMovies()
        {
            return new SuccessDataResult<List<Movie>>(movieDal.GetAll(), "Filmler getirildi");
        }

        public IDataResult<List<Movie>> GetAllMoviesWithCategories()
        {
            return new SuccessDataResult<List<Movie>>(movieDal.GetAllMoviesWithCategories(), "Kategorilerle birlikte filmler getirildi");
        }

        public IDataResult<List<Movie>> GetAllMoviesWithCategoriesByMovieId(int movieId)
        {
            return new SuccessDataResult<List<Movie>>(movieDal.GetMoviesWithCategoriesByMovieId(movieId), "İlgili film getirildi");
        }

        public Movie GetMovieById(int id)
        {
            return movieDal.Get(m => m.MovieId == id);
        }

        public IDataResult<List<Movie>> GetMovieListByWriterId(int id)
        {
            return new SuccessDataResult<List<Movie>>(movieDal.GetAll(m => m.WriterId == id));
        }

        public IDataResult<List<Movie>> GetMovieListByWriterIdWithCategory(int writerId)
        {
            return new SuccessDataResult<List<Movie>>(movieDal.GetMovieListByWriterIdWithCategory(writerId),"İlgili yazara göre filmleri getirildi");
        }

        public IDataResult<List<Movie>> GetMoviesByCategoryId(int id)
        {
            return new SuccessDataResult<List<Movie>>(movieDal.GetAll(m => m.CategoryId == id), $"{id} ye sahip kategorideki filmler getirildi");
        }

        public IResult RemoveMovie(Movie movie)
        {
            movieDal.Delete(movie);
            return new SuccessResult("Film silindi");
        }

        public void UpdateMovie(Movie movie)
        {
            movieDal.Update(movie);
        }
    }
}
