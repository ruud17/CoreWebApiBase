using System.ComponentModel.DataAnnotations;
using CoreWebApiBase.Domain.Enum;

namespace CoreWebApiBase.Domain.Models
{
    public class Movie : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(40, ErrorMessage = "Name should be at most 40 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Release year is required.")]
        [Range(1800, int.MaxValue, ErrorMessage = "Release year must be greater than or equal to 1800.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Release year must be a four-digit number.")]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [EnumDataType(typeof(MovieGenre), ErrorMessage = "Invalid genre.")]
        public MovieGenre Genre { get; set; }
    }
}