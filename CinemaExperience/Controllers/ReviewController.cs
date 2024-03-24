using CinemaExperience.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CinemaExperience.Controllers;

public class ReviewController : BaseController
{
    private readonly IReviewService reviewService;

    public ReviewController(IReviewService _reviewService)
    {
        reviewService = _reviewService;
    }

    [HttpGet]
    public async Task<IActionResult> All(int movieId)
    {
        var reviews = await reviewService.GetAllReviewsByMovieIdAsync(movieId);

        return View(reviews);
    }
}
