using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;

namespace CinemaExperience.Controllers;

public class MovieController : BaseController
{
    private readonly IMovieService movieService;
    private readonly IDirectorService directorService;

    public MovieController(IMovieService _movieService, 
        IDirectorService _directorService)
    {
        movieService = _movieService;
        directorService = _directorService;
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

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new MovieAddViewModel
        {
            Directors = await movieService.GetDirectorsAsync(),
            Genres = await movieService.GetGenresAsync()
        };

        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Add(MovieAddViewModel movieForm)
    {
        if(await directorService.DirectorExistsAsync(movieForm.DirectorId) == false)
        {
            ModelState.AddModelError(nameof(movieForm.DirectorId), "Director does not exist.");
        }
        else if(await movieService.GenreExistsAsync(movieForm.GenreIds) == false)
        {
            ModelState.AddModelError(nameof(movieForm.GenreIds), "Genre does not exist.");
        }

        if (!ModelState.IsValid)
        {
            movieForm.Directors = await movieService.GetDirectorsAsync();
            movieForm.Genres = await movieService.GetGenresAsync();
            return View(movieForm);
        }

        int movieId = await movieService.AddMovieAsync(movieForm);
        return RedirectToAction(nameof(All));
    }

}
