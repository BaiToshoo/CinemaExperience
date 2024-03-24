using CinemaExperience.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

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
