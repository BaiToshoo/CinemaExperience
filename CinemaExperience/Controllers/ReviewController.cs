using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Review;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CinemaExperience.Controllers;

public class ReviewController : BaseController
{
    private readonly IReviewService reviewService;

    public ReviewController(IReviewService _reviewService)
    {
        reviewService = _reviewService;
    }

    [HttpGet]
    public async Task<IActionResult> All(int Id)
    {
        var reviews = await reviewService.GetAllReviewsByMovieIdAsync(Id);

        return View(reviews);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        var reviewForm = await reviewService.EditReviewGetAsync(Id);

        return View(reviewForm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ReviewEditViewModel reviewForm)
    {
        if (reviewForm == null)
        {
            return BadRequest();
        }
        if (User.Id() != reviewForm.UserId && !User.IsInRole("Administrator"))
        {
            return Unauthorized();
        }
        if (!ModelState.IsValid)
        {
            return View(reviewForm);
        }

        var reviewId = await reviewService.EditReviewPostAsync(reviewForm);

        return RedirectToAction(nameof(All), new {id = reviewForm.MovieId});
    }
}
