using CinemaExperience.Core.Helpers;
using CinemaExperience.Core.ViewModels.Admin;
using CinemaExperience.Infrastructure.Identity;

namespace CinemaExperience.Core.Contracts;
public interface IUserService
{
    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByIdAsync(string userId);
    Task<bool> IsCriticAsync(string userId);
    Task<bool> IsAdminAsync(string userId);
    Task<ApplicationUser> GetUserByEmailAsync(string email);
    Task<ApplicationUser> GetUserByIdAsync(string userId);
    Task<PagedResult<UserViewModel>> GetAllUsersAsync(int pageNumber, int pageSize);
}
