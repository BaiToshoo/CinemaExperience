using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Admin;
using CinemaExperience.Infrastructure.Data.Common;
using CinemaExperience.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using static CinemaExperience.Infrastructure.Data.Constants.RoleConstants;

namespace CinemaExperience.Core.Services;
public class AdminService : IAdminService
{
    private readonly IRepository repository;
    private readonly IUserService userService;
    private readonly UserManager<ApplicationUser> userManager;

    public AdminService(IRepository _repository,
        IUserService _userService,
        UserManager<ApplicationUser> _userManager)
    {
        repository = _repository;
        userService = _userService;
        userManager = _userManager;
    }

    public async Task<bool> AddAdminAsync(string userId)
    {
        ApplicationUser user = await userService.GetUserByIdAsync(userId);
        var result = await userManager.AddToRoleAsync(user, AdminRoleName);

        return result.Succeeded;

    }

    public async Task<bool> AddCriticAsync(string criticId)
    {
        ApplicationUser user = await userService.GetUserByIdAsync(criticId);
        if (await userManager.IsInRoleAsync(user,UserRoleName))
        {
            await userManager.RemoveFromRoleAsync(user, UserRoleName);
        }
        var result = await userManager.AddToRoleAsync(user, CriticRoleName);

        return result.Succeeded;
    }

    public async Task<bool> RemoveAdminAsync(string userId)
    {
        ApplicationUser user = await userManager.FindByIdAsync(userId);
        var result = await userManager.RemoveFromRoleAsync(user, AdminRoleName);

        return result.Succeeded;
        
    }

    public async Task<bool> RemoveCriticAsync(string criticId)
    {
        ApplicationUser user = await userManager.FindByIdAsync(criticId);
        if (!await userManager.IsInRoleAsync(user, UserRoleName))
        {
            await userManager.AddToRoleAsync(user, UserRoleName);
        }
        var result = await userManager.RemoveFromRoleAsync(user, CriticRoleName);

        return result.Succeeded;
    }
}
