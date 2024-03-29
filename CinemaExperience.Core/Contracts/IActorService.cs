using CinemaExperience.Core.ViewModels.Actor;

namespace CinemaExperience.Core.Contracts;
public interface IActorService
{
    Task<IEnumerable<AllActorsViewModel>> GetAllActorsAsync();
    Task<ActorDetailsViewModel> GetActorDetailsAsync(int actorId);
    Task<IEnumerable<ActorFormViewModel>> GetActorsForFormAsync();
    Task<int> AddActorAsync(ActorViewModel actorForm);
    Task<ActorViewModel> EditGetAsync(int actorId);
    Task<int> EditPostAsync(ActorViewModel actorForm);
    Task<bool> ActorExistsAsync(int actorId);
}
