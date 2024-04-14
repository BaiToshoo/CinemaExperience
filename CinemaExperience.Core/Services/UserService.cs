using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Admin;
using CinemaExperience.Infrastructure.Data.Common;
using CinemaExperience.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static CinemaExperience.Infrastructure.Data.Constants.RoleConstants;
using CinemaExperience.Core.Helpers;

namespace CinemaExperience.Core.Services;
public class UserService : IUserService
{
    private readonly IRepository repository;
    private readonly UserManager<ApplicationUser> userManager;

    public UserService(IRepository _repository,
        UserManager<ApplicationUser> _userManager)
    {
        repository = _repository;
        userManager = _userManager;
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await repository.AllReadOnly<ApplicationUser>()
            .AnyAsync(u => u.Email.ToLower() == email.ToLower());
    }

    public async Task<bool> ExistsByIdAsync(string userId)
    {
        return await repository.AllReadOnly<ApplicationUser>()
            .AnyAsync(u => u.Id == userId);
    }

    public async Task<ApplicationUser> GetUserByEmailAsync(string email)
    {
        return await repository.AllReadOnly<ApplicationUser>()
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
    }

    public async Task<ApplicationUser> GetUserByIdAsync(string userId)
    {
        return await repository.GetByIdAsync<ApplicationUser>(userId);
    }

    public async Task<PagedResult<UserViewModel>> GetAllUsersAsync(int pageNumber, int pageSize)
    {
        var totalUsers = await repository.AllReadOnly<ApplicationUser>().CountAsync();
        var users = await repository.AllReadOnly<ApplicationUser>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var viewModels = new List<UserViewModel>();

        foreach (var user in users)
        {
            var isAdmin = await userManager.IsInRoleAsync(user, AdminRoleName);
            var isCritic = await userManager.IsInRoleAsync(user, CriticRoleName);

            viewModels.Add(new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FirstName + " " + user.LastName,
                IsAdmin = isAdmin,
                IsCritic = isCritic
            });
        }

        return new PagedResult<UserViewModel>
        {
            Items = viewModels,
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling(totalUsers / (double)pageSize)
        };
    }

    public Task<bool> IsCriticAsync(string userId)
    {
        var user = repository.AllReadOnly<ApplicationUser>()
            .FirstOrDefault(u => u.Id == userId);

        return userManager.IsInRoleAsync(user, CriticRoleName);
    }

    public Task<bool> IsAdminAsync(string userId)
    {
        var user = repository.AllReadOnly<ApplicationUser>()
            .FirstOrDefault(u => u.Id == userId);

        return userManager.IsInRoleAsync(user, AdminRoleName);
    }
}
