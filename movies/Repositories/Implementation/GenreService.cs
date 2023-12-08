using Microsoft.EntityFrameworkCore;
using movies.Models.Domain;
using movies.Repositories.Abstract;

namespace movies.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly MyDBContext _dbContext;

        public GenreService(MyDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool Add(Genre genre)
        {
            try
            {
                _dbContext.Genres.Add(genre);
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
                var genre = this.GetById(id);
                if (genre == null) return false;
                _dbContext.Genres.Remove(genre);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<Genre> GetAll()
        {
            var listGenre = _dbContext.Genres.AsQueryable<Genre>();
            return listGenre;
        }

        public Genre GetById(int id)
        {
            return _dbContext.Genres.Find(id); 
        }

        public bool Update(Genre genre)
        {
            try
            {
                _dbContext.Genres.Update(genre);
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
