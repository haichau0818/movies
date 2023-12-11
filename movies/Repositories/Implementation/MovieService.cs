using Microsoft.EntityFrameworkCore;
using movies.Migrations;
using movies.Models.Domain;
using movies.Repositories.Abstract;

namespace movies.Repositories.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly MyDBContext _dbContext;

        public MovieService(MyDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool Add(Movie movie)
        {
            try
            {
                _dbContext.Movies.Add(movie);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {   
                var movie = this.GetById(id);
                if (movie == null) return false;
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<Movie> GetAll()
        {
            var listMovie = _dbContext.Movies.AsQueryable<Movie>();
            return listMovie;
        }

        public Movie GetById(int id)
        {
            return _dbContext.Movies.Find(id); 
        }

        public bool Update(Movie movie)
        {
            try
            {
                _dbContext.Movies.Update(movie);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
