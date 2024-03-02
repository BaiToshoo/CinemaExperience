using CinemaExperience.Core.Contracts.Movie;
using CinemaExperience.Core.ViewModels.Movie;
using CinemaExperience.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CinemaExperience.Core.Services.Movie;
public class MovieService : IMovieService
{
    private readonly IRepository repository;

    public MovieService(IRepository _repository)
    {
        repository = _repository;
    }

    public async Task<IEnumerable<AllMoviesViewModel>> GetAllMovies()
    {
        return await repository.AllReadOnly<Infrastructure.Data.Models.Movie>()
            .Select(m => new AllMoviesViewModel
            {
               Id = m.Id,
               Director = m.Director.Name,
               Title = m.Title,
               ImageUrl = m.ImageUrl    
            })
            .ToListAsync();

    }
}
