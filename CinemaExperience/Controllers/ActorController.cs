using CinemaExperience.Core.Contracts.Actor;
using Microsoft.AspNetCore.Authorization;
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

}
