using CoreWebApiBase.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiBase.Domain.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> contextOptions) : base(contextOptions)
        {

        }
        public DbSet<Movie> Movies { get; set; }

    }

}