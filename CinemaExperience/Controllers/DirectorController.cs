using CinemaExperience.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CinemaExperience.Controllers;

public class DirectorController : BaseController
{
    private readonly IDirectorService directorService;

    public DirectorController(IDirectorService _directorService)
    {
        directorService = _directorService;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var model = await directorService.GetAllDirectosAsync();

        if (model == null)
        {
            return NotFound();
        }

        return View(model);
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var model = await directorService.GetDirectorDetailsAsync(id);

        if (model == null)
        {
            return NotFound();
        }

        return View(model);
    }
}
