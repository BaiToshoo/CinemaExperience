using CinemaExperience.Core.ViewModels.Admin;

namespace CinemaExperience.Core.Contracts;
public interface IAdminService
{
    Task<bool> AddCriticAsync(string userId);
    Task<bool> RemoveCriticAsync(string criticId);

    Task<bool> AddAdminAsync(string userId);
    Task<bool> RemoveAdminAsync(string userId);
}
