using CinemaExperience.Core.ViewModels.Movie;

namespace CinemaExperience.Core.Contracts.Movie;
public interface IMovieService
{
    Task<IEnumerable<AllMoviesViewModel>> GetAllMovies();
    Task<MovieDetailsViewModel> GetMovieDetailsAsync(int movieId);
}
