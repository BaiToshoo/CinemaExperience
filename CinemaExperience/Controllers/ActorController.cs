using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.Services;
using CinemaExperience.Core.ViewModels.Actor;
using Microsoft.AspNetCore.Mvc;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants;

namespace CinemaExperience.Controllers;

public class ActorController : BaseController
{
    private readonly IActorService actorService;
    private readonly IMovieService movieService;

    public ActorController(IActorService _actorService,
        IMovieService _movieService)
    {
        actorService = _actorService;
        movieService = _movieService;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var model = await actorService.GetAllActorsAsync();

        if (model == null)
        {
            return NotFound();
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var model = await actorService.GetActorDetailsAsync(id);

        if (model == null)
        {
            return NotFound();
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new ActorViewModel()
        {
            Movies = await movieService.GetMoviesForFormAsync()
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ActorViewModel actorForm)
    {
        if (actorForm == null)
        {
            return BadRequest();
        }

        DateTime currentDate = DateTime.Now;
        if (actorForm.BirthDate > currentDate)
        {
            ModelState.AddModelError(nameof(actorForm.BirthDate), BirthDateErrorMessage);
        }

        if (!ModelState.IsValid)
        {
            return View(actorForm);
        }

        var actorId = await actorService.AddActorAsync(actorForm);

        if (actorId == 0)
        {
            return BadRequest();
        }

        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (!await actorService.ActorExistsAsync(id))
        {
            return BadRequest();
        }

        var model = await actorService.EditGetAsync(id);
        model.Movies = await movieService.GetMoviesForFormAsync();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ActorViewModel actorForm)
    {

        if (!await actorService.ActorExistsAsync(actorForm.Id))
        {
            return BadRequest();
        }

        DateTime currentDate = DateTime.Now;
        if (actorForm.BirthDate > currentDate)
        {
            ModelState.AddModelError(nameof(actorForm.BirthDate), BirthDateErrorMessage);
        }

        if (!ModelState.IsValid)
        {
            actorForm.Movies = await movieService.GetMoviesForFormAsync();
            return View(actorForm);
        }

        var actorId = await actorService.EditPostAsync(actorForm);

        if (actorId == 0)
        {
            return BadRequest();
        }

        return RedirectToAction(nameof(Details), new {id = actorForm.Id});
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await actorService.ActorExistsAsync(id))
        {
            return BadRequest();
        }

        var model = await actorService.DeleteAsync(id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!await actorService.ActorExistsAsync(id))
        {
            return BadRequest();
        }

        var directorId = await actorService.DeleteConfirmedAsync(id);

        return RedirectToAction(nameof(All));
    }
}
