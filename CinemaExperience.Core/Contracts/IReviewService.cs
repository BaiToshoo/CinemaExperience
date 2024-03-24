using CinemaExperience.Core.ViewModels.Review;

namespace CinemaExperience.Core.Contracts;
public interface IReviewService
{
    Task<IEnumerable<ReviewViewModel>> GetAllReviewsByMovieIdAsync(int movieId);
    Task <bool> ReviewExistsAsync(int reviewId);
}
