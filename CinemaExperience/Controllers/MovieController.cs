using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.Extensions;
using CinemaExperience.Core.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants;

namespace CinemaExperience.Controllers;

public class MovieController : BaseController
{
	private readonly IMovieService movieService;
	private readonly IDirectorService directorService;
	private readonly IActorService actorService;

	public MovieController(IMovieService _movieService,
		IDirectorService _directorService,
		IActorService _actorService)
	{
		movieService = _movieService;
		directorService = _directorService;
		actorService = _actorService;
	}

	[HttpGet]
	public async Task<IActionResult> All()
	{
		var model = await movieService.GetAllMoviesAsync();

		return View(model);
	}

	[HttpGet]
	public async Task<IActionResult> Details(int id, string information)
	{
		if (!await movieService.MovieExistsAsync(id))
		{
			return BadRequest();
		}

		var model = await movieService.GetMovieDetailsAsync(id);

		if (information != model.GetMovieInformation())
		{
			return BadRequest();
		}

		return View(model);
	}

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		var model = new MovieViewModel()
		{
			Directors = await directorService.GetDirectorsForFormAsync(),
			Genres = await movieService.GetGenresForFormAsync(),
			Actors = await actorService.GetActorsForFormAsync(),

		};

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Add(MovieViewModel movieForm)
	{
		if (await directorService.DirectorExistsAsync(movieForm.DirectorId) == false)
		{
			ModelState.AddModelError(nameof(movieForm.DirectorId), DirectorErrorMessage);
		}
		foreach (var genreId in movieForm.GenreIds)
		{
            if (await movieService.GenreExistsAsync(genreId) == false)
            {
                ModelState.AddModelError(nameof(movieForm.GenreIds), GenreNoExistErrorMessage);
            }
        }
		if (movieForm.GenreIds.Count() < 1)
		{
			ModelState.AddModelError(nameof(movieForm.GenreIds), AtLeastOneGenreErrorMessage);
		}

		if (!ModelState.IsValid)
		{
			movieForm.Directors = await directorService.GetDirectorsForFormAsync();
			movieForm.Genres = await movieService.GetGenresForFormAsync();
			movieForm.Actors = await actorService.GetActorsForFormAsync();
			return View(movieForm);
		}

		int movieId = await movieService.AddMovieAsync(movieForm);
		return RedirectToAction(nameof(All));
	}

	[HttpGet]
	public async Task<IActionResult> Edit(int id, string information)
	{
		if (!await movieService.MovieExistsAsync(id))
		{
			return BadRequest();
		}

		var model = await movieService.EditGetAsync(id);
        model.Directors = await directorService.GetDirectorsForFormAsync();
        model.Actors = await actorService.GetActorsForFormAsync();

        if (model.GetMovieInformation() != information)
		{
			return BadRequest();
		}

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(MovieViewModel movieForm)
	{
		if (!await movieService.MovieExistsAsync(movieForm.Id))
		{
			return BadRequest();
		}

		if (await directorService.DirectorExistsAsync(movieForm.DirectorId) == false)
		{
			ModelState.AddModelError(nameof(movieForm.DirectorId), DirectorErrorMessage);
		}
        foreach (var genreId in movieForm.GenreIds)
        {
            if (await movieService.GenreExistsAsync(genreId) == false)
            {
                ModelState.AddModelError(nameof(movieForm.GenreIds), GenreNoExistErrorMessage);
            }
        }
        if (movieForm.GenreIds.Count() < 1)
		{
			ModelState.AddModelError(nameof(movieForm.GenreIds), AtLeastOneGenreErrorMessage);
		}

		if (!ModelState.IsValid)
		{
			movieForm.Directors = await directorService.GetDirectorsForFormAsync();
			movieForm.Genres = await movieService.GetGenresForFormAsync();
			movieForm.Actors = await actorService.GetActorsForFormAsync();
			return View(movieForm);
		}

		int movieId = await movieService.EditPostAsync(movieForm);

		return RedirectToAction(nameof(Details), new { id = movieForm.Id, information = movieForm.GetMovieInformation() });
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

	[HttpGet]
	public async Task<IActionResult> Delete(int id, string information)
	{
		if (!await movieService.MovieExistsAsync(id))
		{
			return BadRequest();
		}

		var movieToDelete = await movieService.DeleteAsync(id);

		if (movieToDelete.GetMovieInformation() != information)
		{
            return BadRequest();
        }

		return View(movieToDelete);
	}

	[HttpPost]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		if (!await movieService.MovieExistsAsync(id))
		{
			return BadRequest();
		}

		await movieService.DeleteConfirmedAsync(id);

		return RedirectToAction(nameof(All));
	}



}
