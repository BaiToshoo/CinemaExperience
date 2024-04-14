using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Review;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public IActionResult Add(int Id)
    {
        var reviewForm = new ReviewViewModel
        {
            MovieId = Id,
            UserId = User.Id()
        };

        return View(reviewForm);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ReviewViewModel reviewForm)
    {
        if (reviewForm == null)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            return View(reviewForm);
        }

        var reviewId = await reviewService.AddReviewAsync(reviewForm);

        return RedirectToAction(nameof(All), new {id = reviewForm.MovieId});
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        var reviewForm = await reviewService.EditReviewGetAsync(Id);

        if (reviewForm == null)
        {
            return BadRequest();
        }
        if (User.Id() != reviewForm.UserId && !User.IsAdmin())
        {
            return Unauthorized();
        }
        if (!ModelState.IsValid)
        {
            return View(reviewForm);
        }

        return View(reviewForm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ReviewViewModel reviewForm)
    {
        if (reviewForm == null)
        {
            return BadRequest();
        }
        if (User.Id() != reviewForm.UserId && !User.IsAdmin())
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

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        var reviewForm = await reviewService.DeleteAsync(Id);

        if (!await reviewService.ReviewExistsAsync(reviewForm.Id))
        {
            return BadRequest();
        }
        if (User.Id() != reviewForm.UserId && !User.IsAdmin())
        {
            return Unauthorized();
        }

        return View(reviewForm);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(ReviewDeleteViewModel reviewForm)
    {
        if (!await reviewService.ReviewExistsAsync(reviewForm.Id))
        {
            return BadRequest();
        }
        if (User.Id() != reviewForm.UserId && !User.IsAdmin())
        {
            return Unauthorized();
        }

        var reviewId = await reviewService.DeleteConfirmedAsync(reviewForm.Id);

        return RedirectToAction(nameof(All), new {id = reviewForm.MovieId});
    }
}
