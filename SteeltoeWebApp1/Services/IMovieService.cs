using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteeltoeWebApp1.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> IndexAsync();

        Task CreateAsync(Movie movie);

        Task<Movie> DetailsAysnc(int? id);

        Task EditAsync(Movie movie);

        Task DeleteAsync(int? id);
    }
}
