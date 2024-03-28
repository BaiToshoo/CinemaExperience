using CinemaExperience.Core.ViewModels.Actor;

namespace CinemaExperience.Core.Contracts;
public interface IActorService
{
    Task<IEnumerable<AllActorsViewModel>> GetAllActorsAsync();
    Task<ActorDetailsViewModel> GetActorDetailsAsync(int actorId);
    Task<IEnumerable<ActorFormViewModel>> GetActorsForFormAsync();
}
