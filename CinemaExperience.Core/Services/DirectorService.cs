using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Director;
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
    public async Task<IEnumerable<AllDirectorsViewModel>> GetAllDirectosAsync()
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

    public Task<AllDirectorsViewModel> GetDirectorDetailsAsync(int actorId)
    {
        throw new NotImplementedException();
    }
}
