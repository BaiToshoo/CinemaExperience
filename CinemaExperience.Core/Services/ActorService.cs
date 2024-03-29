using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Actor;
using CinemaExperience.Core.ViewModels.Movie;
using CinemaExperience.Infrastructure.Data.Common;
using CinemaExperience.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaExperience.Core.Services;
public class ActorService : IActorService
{
    private readonly IRepository repository;

    public ActorService(IRepository _repository)
    {
        repository = _repository;
    }

    public async Task<bool> ActorExistsAsync(int actorId)
    {
        return await repository.AllReadOnly<Actor>()
            .AnyAsync(a => a.Id == actorId);
    }

    public async Task<ActorViewModel> EditGetAsync(int actorId)
    {
        var currentActor = await repository.GetByIdAsync<Actor>(actorId);

        var actorForm = new ActorViewModel
        {
            Id = actorId,
            Name = currentActor.Name,
            BirthDate = currentActor.BirthDate,
            ImageUrl = currentActor.ImageUrl,
            Biography = currentActor.Biography
        };

        return actorForm;
    }

    public async Task<int> EditPostAsync(ActorViewModel actorForm)
    {
        var currentActor = repository.GetByIdAsync<Actor>(actorForm.Id).Result;

        currentActor.Name = actorForm.Name;
        currentActor.BirthDate = actorForm.BirthDate;
        currentActor.ImageUrl = actorForm.ImageUrl;
        currentActor.Biography = actorForm.Biography;

        await repository.SaveChangesAsync();

        return actorForm.Id;
    }

    public async Task<ActorDetailsViewModel> GetActorDetailsAsync(int actorId)
    {

        var movieDetails = repository.AllReadOnly<Infrastructure.Data.Models.Actor>()
            .Where(a => a.Id == actorId)
            .Select(a => new ActorDetailsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                ImageUrl = a.ImageUrl,
                Biography = a.Biography,
                BirthDate = a.BirthDate,
                Movies = a.MovieActors.Select(ma => new MovieBarViewModel
                {
                    Id = ma.Movie.Id,
                    Title = ma.Movie.Title,
                    ImageUrl = ma.Movie.ImageUrl
                })
            })
            .FirstOrDefaultAsync();

        return await movieDetails;

    }

    public async Task<IEnumerable<ActorFormViewModel>> GetActorsForFormAsync()
    {
        return await repository.AllReadOnly<Infrastructure.Data.Models.Actor>()
            .Select(a => new ActorFormViewModel
            {
                Id = a.Id,
                Name = a.Name
            })
            .ToListAsync();
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
