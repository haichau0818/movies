using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using movies.Models.DTO;
using System.Data;

namespace movies.Models.Domain
{
    public class MyDBContext : IdentityDbContext<ApplicationUser>
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options){
            }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
