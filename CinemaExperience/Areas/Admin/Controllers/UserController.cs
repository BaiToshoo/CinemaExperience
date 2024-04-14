using CinemaExperience.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CinemaExperience.Areas.Admin.Controllers;
public class UserController : AdminBaseController
{
    private readonly IUserService userService;
    private readonly IAdminService adminService;

    public UserController(IUserService _userService,
        IAdminService _adminService)
    {
        userService = _userService;
        adminService = _adminService;
    }

    [HttpGet]
    public async Task<IActionResult> All(int pageNumber = 1, int pageSize = 10)
    {
        var users = await userService.GetAllUsersAsync(pageNumber, pageSize);
        return View(users);
    }

    [HttpGet]
    public async Task<IActionResult> AddAdmin(int pageNumber = 1, int pageSize = 10)
    {
        var users = await userService.GetAllUsersAsync(pageNumber, pageSize);
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> AddAdmin(string userId)
    {
        await adminService.AddAdminAsync(userId);
        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> AddCritic(int pageNumber = 1, int pageSize = 10)
    {
        var users = await userService.GetAllUsersAsync(pageNumber, pageSize);
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> AddCritic(string userId)
    {
        await adminService.AddCriticAsync(userId);
        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> RemoveAdmin(int pageNumber = 1, int pageSize = 10)
    {
        var users = await userService.GetAllUsersAsync(pageNumber, pageSize);
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveAdmin(string userId)
    {
        await adminService.RemoveAdminAsync(userId);
        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> RemoveCritic(int pageNumber = 1, int pageSize = 10)
    {
        var users = await userService.GetAllUsersAsync(pageNumber, pageSize);
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveCritic(string userId)
    {
        await adminService.RemoveCriticAsync(userId);
        return RedirectToAction("All");
    }
}
