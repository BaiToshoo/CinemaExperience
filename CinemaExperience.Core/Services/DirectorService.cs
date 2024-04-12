using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Director;
using CinemaExperience.Core.ViewModels.Movie;
using CinemaExperience.Infrastructure.Data.Common;
using CinemaExperience.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaExperience.Core.Services;
public class DirectorService : IDirectorService
{
    private readonly IRepository repository;

    public DirectorService(IRepository _repository)
    {
        repository = _repository;
    }

    public async Task<int> AddDirectorAsync(DirectorViewModel directorForm)
    {
        var director = new Director
        {
            Name = directorForm.Name,
            BirthDate = directorForm.BirthDate,
            ImageUrl = directorForm.ImageUrl,
            Biography = directorForm.Biography
        };
        await repository.AddAsync(director);
        await repository.SaveChangesAsync();

        return director.Id;
    }

    public async Task<DirectorDeleteViewModel> DeleteAsync(int directorId)
    {
        var director = await repository.AllReadOnly<Director>()
            .Where(d => d.Id == directorId)
            .Select(d => new DirectorDeleteViewModel
            {
                Id = d.Id,
                Name = d.Name,
                ImageUrl = d.ImageUrl
            })
            .FirstOrDefaultAsync();

        return director;
    }

    public async Task<int> DeleteConfirmedAsync(int directorId)
    {
        var director = await repository.GetByIdAsync<Director>(directorId);

        await repository.DeleteAsync(director);
        await repository.SaveChangesAsync();

        return director.Id;
    }

    public async Task<bool> DirectorExistsAsync(int directorId)
    {
        return await repository.AllReadOnly<Director>()
            .AnyAsync(d => d.Id == directorId);
    }

    public async Task<DirectorViewModel> EditGetAsync(int directorId)
    {
        var currentDirector = await repository.GetByIdAsync<Director>(directorId);

        var directorForm = new DirectorViewModel
        {
            Id = directorId,
            Name = currentDirector.Name,
            BirthDate = currentDirector.BirthDate,
            ImageUrl = currentDirector.ImageUrl,
            Biography = currentDirector.Biography
        };

        return directorForm;
    }

    public async Task<int> EditPostAsync(DirectorViewModel directorForm)
    {
        var director = repository.GetByIdAsync<Director>(directorForm.Id).Result;

        director.Name = directorForm.Name;
        director.BirthDate = directorForm.BirthDate;
        director.ImageUrl = directorForm.ImageUrl;
        director.Biography = directorForm.Biography;

        await repository.SaveChangesAsync();

        return director.Id;
    }

    public async Task<IEnumerable<AllDirectorsViewModel>> GetAllDirectorsAsync()
    {
        return await repository.AllReadOnly<Director>()
            .Select(d => new AllDirectorsViewModel
            {
                Id = d.Id,
                Name = d.Name,
                ImageUrl = d.ImageUrl
            })
            .ToListAsync();
    }

    public async Task<DirectorDetailsViewModel> GetDirectorDetailsAsync(int directorId)
    {
        var directorDetails = repository.AllReadOnly<Director>()
            .Where(d => d.Id == directorId)
            .Select(d => new DirectorDetailsViewModel
            {
                Id = d.Id,
                Name = d.Name,
                BirthDate = d.BirthDate,
                ImageUrl = d.ImageUrl,
                Biography = d.Biography,
                Movies = d.Movies.Select(m => new MovieBarViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    ImageUrl = m.ImageUrl
                })
            })
            .FirstOrDefaultAsync();

        return await directorDetails;
    }

    public async Task<IEnumerable<DirectorFormViewModel>> GetDirectorsForFormAsync()
    {
        return await repository.AllReadOnly<Director>()
             .Select(d => new DirectorFormViewModel
             {
                 Id = d.Id,
                 Name = d.Name
             })
             .ToListAsync();
    }
}
