using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMovieDal : EfRepositoryBase<Movie, Context>, IMovieDal
    {
        public List<Movie> GetAllMoviesWithCategories()
        {
            using (var c = new Context())
            {
                return c.Movies.Include(x => x.Category).ToList();
            }
        }

        public List<Movie> GetMovieListByWriterIdWithCategory(int writerId)
        {
            using (var c = new Context())
            {
                return c.Movies.Include(x => x.Category).Where(x=>x.WriterId == writerId).ToList();
            }
        }

        public List<Movie> GetMoviesWithCategoriesByMovieId(int movieId)
        {
            using (var c = new Context())
            {
                return c.Movies.Include(x => x.Category).Where(x=> x.MovieId == movieId).ToList();
            }
        }
    }
}
