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

    public async Task<IEnumerable<ReviewViewModel>> GetAllReviewsByMovieIdAsync(int movieId)
    {
        var reviews = await repository.AllReadOnly<Review>()
            .Where(r => r.MovieId == movieId)
            .OrderByDescending(r => r.PostedOn)
            .Select(r => new ReviewViewModel
            {
                Id = r.Id,
                MovieId = r.MovieId,
                Content = r.Content,
                Rating = r.Rating,
                PostedOn = r.PostedOn,
                AuthorId = r.User.Id,
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
