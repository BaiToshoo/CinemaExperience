using CinemaExperience.Core.ViewModels.Review;
using CinemaExperience.Infrastructure.Data.Models;

namespace CinemaExperience.Core.Contracts;
public interface IReviewService
{
    Task<IEnumerable<ReviewViewModel>> GetAllReviewsByMovieIdAsync(int movieId);
    Task <bool> ReviewExistsAsync(int reviewId);
    Task<ReviewEditViewModel> EditReviewGetAsync(int reviewId);
    Task<int> EditReviewPostAsync(ReviewEditViewModel reviewForm);

}
