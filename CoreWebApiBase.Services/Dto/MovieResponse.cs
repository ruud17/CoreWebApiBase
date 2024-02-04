using CoreWebApiBase.Domain.Enum;

namespace CoreWebApiBase.Services.Dto
{
    public class MovieResponseDto
    {
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public MovieGenre Genre { get; set; }
    }
}