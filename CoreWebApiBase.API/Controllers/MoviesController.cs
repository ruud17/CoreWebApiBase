using CoreWebApiBase.Services.Dto;
using CoreWebApiBase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieRequestDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isMovieCreated = await _movieService.CreateMovie(movieDto);

            return isMovieCreated ? Ok(movieDto) : BadRequest();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieById(id);

            if (movie != null)
            {
                return Ok(movie);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateMovie(int id, MovieRequestDto movieDto)
        {
            if (movieDto != null)
            {
                var movieCreated = await _movieService.UpdateMovie(id, movieDto);
                if (movieCreated)
                {
                    return Ok(movieCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movieDeleted = await _movieService.DeleteMovie(id);

            if (movieDeleted)
            {
                return Ok(movieDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}