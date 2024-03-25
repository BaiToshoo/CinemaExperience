using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Review;
using CinemaExperience.Infrastructure.Data.Common;
using CinemaExperience.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaExperience.Core.Services;
public class ReviewService : IReviewService
{
    private readonly IRepository repository;

    public ReviewService(IRepository _repository)
    {
        repository = _repository;
    }

    public async Task<ReviewEditViewModel> EditReviewGetAsync(int reviewId)
    {
        var currentReview = await repository.GetByIdAsync<Review>(reviewId);

        var reviewForm = new ReviewEditViewModel()
        {
            Id = currentReview.Id,
            MovieId = currentReview.MovieId,
            UserId = currentReview.UserId,
            Content = currentReview.Content,
            Rating = currentReview.Rating,
        };

        return reviewForm;
    }

    public async Task<int> EditReviewPostAsync(ReviewEditViewModel reviewForm)
    {
        var currentReview = await repository.GetByIdAsync<Review>(reviewForm.Id);

        currentReview.Content = reviewForm.Content;
        currentReview.Rating = reviewForm.Rating;

        await repository.SaveChangesAsync();

        return currentReview.Id;
    }

    public async Task<IEnumerable<ReviewViewModel>> GetAllReviewsByMovieIdAsync(int movieId)
    {
        var reviews = await repository.AllReadOnly<Review>()
            .Where(r => r.MovieId == movieId)
            .OrderByDescending(r => r.PostedOn)
            .Select(r => new ReviewViewModel()
            {
                Id = r.Id,
                MovieId = r.MovieId,
                Content = r.Content,
                Rating = r.Rating,
                PostedOn = r.PostedOn,
                UserId = r.User.Id,
                AuthorName = r.User.FirstName + " " + r.User.LastName,
            })
            .ToListAsync();

        return reviews;
    }

    public Task<bool> ReviewExistsAsync(int reviewId)
    {
        return repository.AllReadOnly<Review>().AnyAsync(r => r.Id == reviewId);
    }
}
