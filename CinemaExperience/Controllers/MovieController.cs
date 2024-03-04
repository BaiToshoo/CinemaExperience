using CinemaExperience.Core.Contracts.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaExperience.Controllers;

public class MovieController : BaseController
{
    private readonly IMovieService movieService;

    public MovieController(IMovieService _movieService)
    {
        movieService = _movieService;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var model = await movieService.GetAllMoviesAsync();

        if (model == null)
        {
            return NotFound();

        }

        return View(model);
    }

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
