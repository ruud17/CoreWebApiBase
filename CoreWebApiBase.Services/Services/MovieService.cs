using AutoMapper;
using CoreWebApiBase.Domain.Interfaces;
using CoreWebApiBase.Domain.Models;
using CoreWebApiBase.Services.Dto;
using CoreWebApiBase.Services.Interfaces;

namespace CoreWebApiBase.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Movie> _repository;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetEntityRepository<Movie>();
            _mapper = mapper;
        }

        public async Task<bool> CreateMovie(MovieRequestDto movie)
        {
            await _repository.Add(_mapper.Map<Movie>(movie));
            var result = await _unitOfWork.SaveAsync();

            return result > 0;
        }

        public async Task<IEnumerable<MovieResponseDto>> GetAllMovies()
        {
            var movies = await _repository.GetAll();
            return _mapper.Map<IEnumerable<MovieResponseDto>>(movies);
        }

        public async Task<MovieResponseDto?> GetMovieById(int id)
        {

            var movie = await _repository.GetById(id);
            return movie != null ? _mapper.Map<MovieResponseDto>(movie) : null;
        }

        public async Task<bool> UpdateMovie(int id, MovieRequestDto movieDto)
        {
            var movie = await _repository.GetById(id);

            if (movie != null)
            {
                movie.Name = movieDto.Name;
                movie.ReleaseYear = movieDto.ReleaseYear;
                movie.Genre = movieDto.Genre;

                _repository.Update(movie);
                var result = await _unitOfWork.SaveAsync();

                return result > 0;
            }
            return false;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await _repository.GetById(id);

            if (movie != null)
            {
                _repository.Delete(movie);
                var result = await _unitOfWork.SaveAsync();

                return result > 0;
            }
            return false;
        }
    }
}