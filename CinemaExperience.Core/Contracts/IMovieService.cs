using CinemaExperience.Core.ViewModels.Genre;
using CinemaExperience.Core.ViewModels.Movie;
using CinemaExperience.Core.ViewModels.Review;

namespace CinemaExperience.Core.Contracts;
public interface IMovieService
{
    Task<IEnumerable<AllMoviesViewModel>> GetAllMoviesAsync();
    Task<MovieDetailsViewModel> GetMovieDetailsAsync(int movieId);
    Task<IEnumerable<ReviewFormViewModel>> GetLatestReviewsAsync(int movieId);
    Task<bool> GenreExistsAsync(int genreId);
    Task<bool> MovieExistsAsync(int movieId);
    Task<IEnumerable<GenreViewModel>> GetGenresForFormAsync();
    Task<int> AddMovieAsync(MovieViewModel movieForm);
    Task<IEnumerable<AllMoviesViewModel>> SearchAsync(string input);
    Task<MovieDeleteViewModel> DeleteAsync(int movieId);
    Task<int> DeleteConfirmedAsync(int movieId);
    Task<MovieViewModel> EditGetAsync(int movieId);
    Task<int> EditPostAsync(MovieViewModel movieForm);
    Task<IEnumerable<MovieFormViewModel>> GetMoviesForFormAsync();
}
