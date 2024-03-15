using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants;

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

		return View(model);
	}

	[HttpGet]
	public async Task<IActionResult> Details(int id)
	{
		if (!await movieService.MovieExistsAsync(id))
		{
			return BadRequest();
		}

		var model = await movieService.GetMovieDetailsAsync(id);
		model.LatestReviews = await movieService.GetLatestReviewsAsync(id);

		return View(model);
	}

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		var model = new AddMovieViewModel
		{
			Directors = await movieService.GetDirectorsAsync(),
			Genres = await movieService.GetGenresAsync()
		};

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Add(AddMovieViewModel movieForm)
	{
		if (await directorService.DirectorExistsAsync(movieForm.DirectorId) == false)
		{
			ModelState.AddModelError(nameof(movieForm.DirectorId), DirectorErrorMessage);
		}
		if (await movieService.GenreExistsAsync(movieForm.GenreIds) == false)
		{
			ModelState.AddModelError(nameof(movieForm.GenreIds), GenreNoExistErrorMessage);
		}
		if (movieForm.GenreIds.Count() < 1)
		{
			ModelState.AddModelError(nameof(movieForm.GenreIds), AtLeastOneGenreErrorMessage);
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

	[HttpGet]
	public async Task<IActionResult> Search(string input)
	{
		if (input == null)
		{
			return RedirectToAction(nameof(All));
		}

		var searchedMovie = await movieService.SearchAsync(input);

		if (searchedMovie == null)
		{
			return RedirectToAction(nameof(All));
		}

		return View(searchedMovie);
	}


}
