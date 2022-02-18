using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using SteeltoeWebApp1.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteeltoeWebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly SteeltoeWebApi1Context _context;

        public MoviesController(SteeltoeWebApi1Context context)
        {
            _context = context;
        }

        // GET: Movies
        [HttpGet("index")]
        public async Task<IEnumerable<Movie>> Index()
        {
            IEnumerable<Movie> movies = await _context.Movie.ToListAsync();
            return movies;
        }

        // GET: Movies/Details/5
        [HttpGet("details")]
        public async Task<Movie> Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return null;
            }

            return movie;
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("create")]
        public async Task<Movie> Create([FromBody] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
            }
            return movie;
        }

        // POST: Movies/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("edit")]
        public async Task<Movie> Edit([FromBody] Movie movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return movie;
            }
            return null;
        }

        // POST: Movies/Delete/5
        [HttpDelete("delete/{id}")]
        public async Task DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
