using AutoMapper;
using CoreWebApiBase.Domain.Models;
using CoreWebApiBase.Services.Dto;

namespace CoreWebApiBase.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieResponseDto>();
            CreateMap<MovieRequestDto, Movie>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.ToString()));
        }
    }
}