using CinemaExperience.Core.ViewModels.Review;
using CinemaExperience.Infrastructure.Data.Models;

namespace CinemaExperience.Core.Contracts;
public interface IReviewService
{
    Task<IEnumerable<ReviewFormViewModel>> GetAllReviewsByMovieIdAsync(int movieId);
    Task <bool> ReviewExistsAsync(int reviewId);
    Task<ReviewViewModel> EditReviewGetAsync(int reviewId);
    Task<int> EditReviewPostAsync(ReviewViewModel reviewForm);
    Task<int> AddReviewAsync(ReviewViewModel reviewForm);

}
