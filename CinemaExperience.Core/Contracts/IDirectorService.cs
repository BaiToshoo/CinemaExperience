using CinemaExperience.Core.ViewModels.Director;

namespace CinemaExperience.Core.Contracts;
public interface IDirectorService
{
    Task<IEnumerable<AllDirectorsViewModel>> GetAllDirectosAsync();
    Task<DirectorDetailsViewModel> GetDirectorDetailsAsync(int actorId);
    Task<bool> DirectorExistsAsync(int directorId);
}
