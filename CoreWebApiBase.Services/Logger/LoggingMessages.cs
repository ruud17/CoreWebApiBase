namespace CoreWebApiBase.Services.Logger
{
    public class LoggingMessages
    {
        public static string GetMovieLogMessage(LogMessageType messageType, string? movieName = null, int? movieId = null)
        {
            return messageType switch
            {   // SUCCESS msgs
                LogMessageType.MovieCreated => $"Movie '{movieName}' successfully created.",
                LogMessageType.MovieUpdated => $"Movie '{movieName}' with id:'{movieId}' successfully updated.",
                LogMessageType.GetAllMovies => $"All movies successfully retrieved.",
                LogMessageType.GetSingleMovie => $"Movie '{movieName}' with id: '{movieId}' successfully retrieved.",
                LogMessageType.MovieDeleted => $"Movie with id:'{movieId}' successfully deleted.",

                // ERROR msgs
                LogMessageType.MovieCreateError => $"An unexpected error occurred while creating movie '{movieName}'",
                LogMessageType.MovieUpdateError => $"An unexpected error occurred while updating movie '{movieName}' with id:'{movieId}'",
                LogMessageType.MovieDeleteError => $"An unexpected error occurred while deleting movie with id:'{movieId}'",
                LogMessageType.GetAllMoviesError => $"An unexpected error occurred while getting all movies",
                LogMessageType.GetSingleMovieError => $"An unexpected error occurred while getting movie with id '{movieId}'",
                LogMessageType.CommonError => $"An unexpected error occurred!",

                _ => $"Unexpected log message type: {messageType}",
            };
        }
    }
}
