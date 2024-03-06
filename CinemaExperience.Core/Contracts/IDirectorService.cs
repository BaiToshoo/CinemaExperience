using CinemaExperience.Core.ViewModels.Actor;
using CinemaExperience.Core.ViewModels.Director;

namespace CinemaExperience.Core.Contracts;
public interface IDirectorService
{
    Task<IEnumerable<AllDirectorsViewModel>> GetAllDirectosAsync();
    Task<AllDirectorsViewModel> GetDirectorDetailsAsync(int actorId);
}
