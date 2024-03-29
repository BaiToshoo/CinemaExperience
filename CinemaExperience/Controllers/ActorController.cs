using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Actor;
using Microsoft.AspNetCore.Mvc;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants;

namespace CinemaExperience.Controllers;

public class ActorController : BaseController
{
    private readonly IActorService actorService;

    public ActorController(IActorService _actorService)
    {
        actorService = _actorService;
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
    public async Task<IActionResult> Edit(int id)
    {
        if (!await actorService.ActorExistsAsync(id))
        {
            return BadRequest();
        }

        var model = await actorService.EditGetAsync(id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ActorViewModel actorForm)
    {
        if (actorForm == null)
        {
            return BadRequest();
        }

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
            return View(actorForm);
        }

        var actorId = await actorService.EditPostAsync(actorForm);

        if (actorId == 0)
        {
            return BadRequest();
        }

        return RedirectToAction(nameof(All));
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

}
