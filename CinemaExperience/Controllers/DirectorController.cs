using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.Services;
using CinemaExperience.Core.ViewModels.Director;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants;
using static CinemaExperience.Infrastructure.Data.Constants.RoleConstants;

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
        var model = await directorService.GetAllDirectorsAsync();

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

    [HttpGet]
    [Authorize(Roles = AdminRoleName)]
    public async Task<IActionResult> Add()
    {
        var model = new DirectorViewModel();
        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = AdminRoleName)]
    public async Task<IActionResult> Add(DirectorViewModel directorForm)
    {
        if (directorForm == null)
        {
            return BadRequest();
        }
        DateTime currentDate = DateTime.Now;
        if (directorForm.BirthDate > currentDate)
        {
            ModelState.AddModelError(nameof(directorForm.BirthDate), BirthDateErrorMessage);
        }
        if (!ModelState.IsValid)
        {
            return View(directorForm);
        }

        var directorId = await directorService.AddDirectorAsync(directorForm);

        if (directorId == 0)
        {
            return BadRequest();
        }

        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    [Authorize(Roles = AdminRoleName)]
    public async Task<IActionResult> Edit(int id)
    {
        if (!await directorService.DirectorExistsAsync(id)) 
        { 
            return BadRequest();
        }

        var model = await directorService.EditGetAsync(id);


        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = AdminRoleName)]
    public async Task<IActionResult> Edit(DirectorViewModel directorForm)
    {
        if (!await directorService.DirectorExistsAsync(directorForm.Id))
        {
            return BadRequest();
        }
        DateTime currentDate = DateTime.Now;
        if (directorForm.BirthDate > currentDate)
        {
            ModelState.AddModelError(nameof(directorForm.BirthDate), BirthDateErrorMessage);
        }
        if (!ModelState.IsValid)
        {
            return View(directorForm);
        }

        var directorId = await directorService.EditPostAsync(directorForm);

        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    [Authorize(Roles = AdminRoleName)]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await directorService.DirectorExistsAsync(id))
        {
            return BadRequest();
        }

        var model = await directorService.DeleteAsync(id);

        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = AdminRoleName)]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!await directorService.DirectorExistsAsync(id))
        {
            return BadRequest();
        }

        var directorId = await directorService.DeleteConfirmedAsync(id);

        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Search(string input)
    {
        if (input == null)
        {
            return RedirectToAction(nameof(All));
        }

        var searchedDirector = await directorService.SearchAsync(input);

        if (searchedDirector == null)
        {
            return RedirectToAction(nameof(All));
        }

        return View(searchedDirector);
    }
}
