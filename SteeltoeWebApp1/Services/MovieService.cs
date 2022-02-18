using Microsoft.Extensions.Logging;
using MvcMovie.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SteeltoeWebApp1.Services
{
    public class MovieService : IMovieService
    {
        private readonly ILogger<MovieService> _logger;
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public MovieService(HttpClient httpClient, ILoggerFactory logFactory)
        {
            _logger = logFactory.CreateLogger<MovieService>();
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Movie>> IndexAsync()
        {
            var result = await _httpClient.GetStringAsync("index");
            _logger.LogInformation("IndexAsync: {0}", result);
            return JsonConvert.DeserializeObject<IEnumerable<Movie>>(result, settings);
        }

        public async Task CreateAsync(Movie movie)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "create");
            request.Content = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(movie), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }

        public async Task<Movie> DetailsAysnc(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var movies = await this.IndexAsync().ConfigureAwait(false);

            return movies.FirstOrDefault(m => m.Id == id);
        }


        public async Task EditAsync(Movie movie)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "edit");
            request.Content = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(movie), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }

        public async Task DeleteAsync(int? id)
        {
            if (id != null)
            {
                await _httpClient.DeleteAsync($"delete/{id}");
            }
        }
    }
}