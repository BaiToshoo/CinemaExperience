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

    public async Task<int> AddActorAsync(ActorViewModel actorForm)
    {
        var actor = new Actor
        {
            Name = actorForm.Name,
            BirthDate = actorForm.BirthDate,
            ImageUrl = actorForm.ImageUrl,
            Biography = actorForm.Biography,
            MovieActors = actorForm.MovieIds.Select(m => new MovieActor
            {
                MovieId = m
            }).ToList()
        };
        await repository.AddAsync(actor);
        await repository.SaveChangesAsync();

        return actor.Id;
    }

    public async Task<ActorViewModel> EditGetAsync(int actorId)
    {
        var currentActor = await repository.AllReadOnly<Actor>()
            .Include(a => a.MovieActors)
            .FirstOrDefaultAsync(a => a.Id == actorId);

        var actorForm = new ActorViewModel
        {
            Id = actorId,
            Name = currentActor.Name,
            BirthDate = currentActor.BirthDate,
            ImageUrl = currentActor.ImageUrl,
            Biography = currentActor.Biography,
            MovieIds = currentActor.MovieActors.Select(ma => ma.MovieId)
        };

        return actorForm;
    }

    public async Task<int> EditPostAsync(ActorViewModel actorForm)
    {
        var currentActor = await repository.All<Actor>()
            .Include(a => a.MovieActors)
            .FirstOrDefaultAsync(a => a.Id == actorForm.Id);

        currentActor.Name = actorForm.Name;
        currentActor.BirthDate = actorForm.BirthDate;
        currentActor.ImageUrl = actorForm.ImageUrl;
        currentActor.Biography = actorForm.Biography;

        var currentMovieIds = currentActor.MovieActors.Select(ma => ma.MovieId).ToList();

        var movieIdsToAdd = actorForm.MovieIds.Except(currentMovieIds).ToList();
        var movieIdsToRemove = currentMovieIds.Except(actorForm.MovieIds).ToList();

        foreach (var movieId in movieIdsToAdd)
        {
            currentActor.MovieActors.Add(new MovieActor { MovieId = movieId });
        }

        var movieActorsToRemove = currentActor.MovieActors
            .Where(ma => movieIdsToRemove.Contains(ma.MovieId))
            .ToList();

        await repository.DeleteRangeAsync(movieActorsToRemove);

        await repository.SaveChangesAsync();

        return actorForm.Id;
    }

    public async Task<ActorDetailsViewModel> GetActorDetailsAsync(int actorId)
    {

        var movieDetails = repository.AllReadOnly<Actor>()
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
        return await repository.AllReadOnly<Actor>()
            .Select(a => new ActorFormViewModel
            {
                Id = a.Id,
                Name = a.Name
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<AllActorsViewModel>> GetAllActorsAsync()
    {
        return await repository.AllReadOnly<Actor>()
            .Select(a => new AllActorsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                ImageUrl = a.ImageUrl,
            })
            .ToListAsync();
    }
}
