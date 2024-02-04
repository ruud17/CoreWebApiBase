using System.ComponentModel.DataAnnotations;
using CoreWebApiBase.Domain.Enum;

public class GenreValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        MovieGenre[] allowedGenres = { MovieGenre.Action, MovieGenre.Comedy, MovieGenre.Romance, MovieGenre.Thriller, MovieGenre.SF, MovieGenre.Horror };

        if (!allowedGenres.Contains((MovieGenre)value))
        {
            return new ValidationResult("Genre is not one of the possible values.");
        }

        return ValidationResult.Success;
    }
}