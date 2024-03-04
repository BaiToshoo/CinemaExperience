using CinemaExperience.Core.Contracts.Actor;
using CinemaExperience.Core.ViewModels.Actor;
using CinemaExperience.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CinemaExperience.Core.Services.Actor;
public class ActorService : IActorService
{
    private readonly IRepository repository;

    public ActorService(IRepository _repository)
    {
        repository = _repository;
    }

    public async Task<IEnumerable<AllActorsViewModel>> GetAllActorsAsync()
    {
        return await repository.AllReadOnly<Infrastructure.Data.Models.Actor>()
            .Select(a => new AllActorsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                ImageUrl = a.ImageUrl,
            })
            .ToListAsync();
    }
}
