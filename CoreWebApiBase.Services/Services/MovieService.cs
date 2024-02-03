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
        // public async Task<IEnumerable<MovieResponseDto>> GetAllMovies()
        // {
        //     var movies = await _movieRepository.GetAll();
        //     return _mapper.Map<IEnumerable<MovieDto>>(movies);
        // }

        //    public async Task<MovieDto> GetMovieById(int id)
        // {
        //     var movie = await _movieRepository.GetById(id);
        //     return _mapper.Map<MovieDto>(movie);
        // }



        // private readonly IUnitOfWork _unitOfWork;

        // public YourEntityService(IUnitOfWork unitOfWork)
        // {
        //     _unitOfWork = unitOfWork;
        // }

        public async Task<IEnumerable<MovieResponseDto>> GetAllMovies()
        {
            var movies = await _repository.GetAll();
            return _mapper.Map<IEnumerable<MovieResponseDto>>(movies);
        }

        // public async Task<YourEntity> GetYourEntityById(int id)
        // {
        //     return await _unitOfWork.YourEntityRepository.GetById(id);
        // }

        // public async Task AddYourEntity(YourEntity entity)
        // {
        //     await _unitOfWork.YourEntityRepository.Add(entity);
        //     await _unitOfWork.SaveAsync();
        // }

        public async Task<bool> CreateMovie(MovieRequestDto movie)
        {
            if (movie != null)
            {
                await _repository.Add(_mapper.Map<Movie>(movie));
                var result = await _unitOfWork.SaveAsync();

                return result > 0;
            }
            return false;
        }

        // public void DeleteYourEntity(YourEntity entity)
        // {
        //     _unitOfWork.YourEntityRepository.Delete(entity);
        //     _unitOfWork.SaveAsync().Wait(); // This is blocking, consider making it asynchronous
        // }

        // public void UpdateYourEntity(YourEntity entity)
        // {
        //     _unitOfWork.YourEntityRepository.Update(entity);
        //     _unitOfWork.SaveAsync().Wait(); // This is blocking, consider making it asynchronous
        // }
    }
}