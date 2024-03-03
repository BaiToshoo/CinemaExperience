using CinemaExperience.Core.ViewModels.Movie;
using CinemaExperience.Core.ViewModels.Review;

namespace CinemaExperience.Core.Contracts.Movie;
public interface IMovieService
{
    Task<IEnumerable<AllMoviesViewModel>> GetAllMovies();
    Task<MovieDetailsViewModel> GetMovieDetailsAsync(int movieId);
    Task<IEnumerable<ReviewViewModel>> GetLatestReviewsAsync(int movieId);
}
