using Microsoft.EntityFrameworkCore;

namespace SteeltoeWebApp1.Data
{
    public class SteeltoeWebApi1Context : DbContext
    {
        public SteeltoeWebApi1Context(DbContextOptions<SteeltoeWebApi1Context> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; }
    }
}
