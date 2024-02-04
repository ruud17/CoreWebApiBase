using CoreWebApiBase.Services.Dto;
using CoreWebApiBase.Services.Interfaces;
using CoreWebApiBase.Services.Logger;
using Microsoft.AspNetCore.Mvc;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public readonly IMovieService _movieService;
        private readonly ILoggerService _logger;

        public MoviesController(IMovieService movieService, ILoggerService logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieRequestDto movieDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var movieSuccessfullyCreated = await _movieService.CreateMovie(movieDto);

                if (movieSuccessfullyCreated)
                {
                    _logger.LogInformation(LoggingMessages.GetMovieLogMessage(LogMessageType.MovieCreated, movieDto.Name));
                    return CreatedAtAction(nameof(CreateMovie), movieDto);
                }

                _logger.LogError(LoggingMessages.GetMovieLogMessage(LogMessageType.MovieCreateError, movieDto.Name));
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingMessages.GetMovieLogMessage(LogMessageType.CommonError), ex);
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                var movies = await _movieService.GetAllMovies();
                if (movies != null)
                {
                    _logger.LogInformation(LoggingMessages.GetMovieLogMessage(LogMessageType.GetAllMovies));
                    return Ok(movies);
                }

                _logger.LogError(LoggingMessages.GetMovieLogMessage(LogMessageType.GetAllMoviesError));
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingMessages.GetMovieLogMessage(LogMessageType.CommonError), ex);
                return StatusCode(500, ex);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            try
            {
                var movie = await _movieService.GetMovieById(id);
                if (movie != null)
                {
                    _logger.LogInformation(LoggingMessages.GetMovieLogMessage(LogMessageType.GetSingleMovie, movie.Name, id));
                    return Ok(movie);
                }

                _logger.LogError(LoggingMessages.GetMovieLogMessage(LogMessageType.GetSingleMovieError, null, id));
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingMessages.GetMovieLogMessage(LogMessageType.CommonError), ex);
                return StatusCode(500, ex);
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieRequestDto movieDto)
        {
            try
            {
                var movieCreated = await _movieService.UpdateMovie(id, movieDto);
                if (movieCreated)
                {
                    _logger.LogInformation(LoggingMessages.GetMovieLogMessage(LogMessageType.MovieUpdated, movieDto.Name, id));
                    return Ok(movieCreated);
                }

                _logger.LogError(LoggingMessages.GetMovieLogMessage(LogMessageType.MovieUpdateError, movieDto.Name, id));
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingMessages.GetMovieLogMessage(LogMessageType.CommonError), ex);
                return StatusCode(500, ex);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                var movieDeleted = await _movieService.DeleteMovie(id);

                if (movieDeleted)
                {
                    _logger.LogInformation(LoggingMessages.GetMovieLogMessage(LogMessageType.MovieDeleted, null, id));
                    return Ok(movieDeleted);
                }

                _logger.LogError(LoggingMessages.GetMovieLogMessage(LogMessageType.MovieDeleteError, null, id));
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingMessages.GetMovieLogMessage(LogMessageType.CommonError), ex);
                return StatusCode(500, ex);
            }

        }
    }
}