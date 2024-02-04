

using CoreWebApiBase.Services.Dto;

namespace CoreWebApiBase.Services.Interfaces
{
    public interface IMovieService
    {
        Task<bool> CreateMovie(MovieRequestDto movie);
        public Task<IEnumerable<MovieResponseDto>> GetAllMovies();
        Task<MovieResponseDto?> GetMovieById(int id);
        Task<bool> UpdateMovie(int id, MovieRequestDto movie);
        Task<bool> DeleteMovie(int id);
    }
}