using movies.Models.Domain;

namespace movies.Repositories.Abstract
{
    public interface IMovieService
    {
        bool Add(Movie movie);
        bool Update(Movie genre);
        bool Delete(int id);

        IQueryable<Movie> GetAll();
        Movie GetById(int id);
    }
}
