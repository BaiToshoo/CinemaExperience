using CinemaExperience.Core.Contracts.Movie;
using CinemaExperience.Core.ViewModels.Movie;
using CinemaExperience.infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaExperience.Controllers;

[Authorize]
public class MovieController : Controller
{
    private readonly IMovieService movieService;

    public MovieController(IMovieService _movieService)
    {
        movieService = _movieService;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> All()
    {
        var model = await movieService.GetAllMovies();

        if (model == null)
        {
            return NotFound();

        }

        return View(model);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var model = await movieService.GetMovieDetailsAsync(id);
        model.LatestReviews = await movieService.GetLatestReviewsAsync(id);

        if (model.LatestReviews == null)
        {
            return NotFound();
        }

        return View(model);
    }

}
