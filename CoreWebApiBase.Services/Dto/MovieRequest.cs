using CoreWebApiBase.Domain.Enum;

namespace CoreWebApiBase.Services.Dto
{
    public class MovieRequestDto
    {
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public MovieGenre Genre { get; set; }
    }
}