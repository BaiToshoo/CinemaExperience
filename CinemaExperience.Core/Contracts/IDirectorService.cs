using CinemaExperience.Core.ViewModels.Director;

namespace CinemaExperience.Core.Contracts;
public interface IDirectorService
{
    Task<IEnumerable<AllDirectorsViewModel>> GetAllDirectorsAsync();
    Task<DirectorDetailsViewModel> GetDirectorDetailsAsync(int directorId);
    Task<bool> DirectorExistsAsync(int directorId);
    Task<int> AddDirectorAsync(DirectorViewModel directorForm);
    Task<DirectorViewModel> EditGetAsync(int directorId);
    Task<int> EditPostAsync(DirectorViewModel directorForm);
    Task<DirectorDeleteViewModel> DeleteAsync(int directorId);
    Task<int> DeleteConfirmedAsync(int directorId);
    Task<IEnumerable<DirectorFormViewModel>> GetDirectorsForFormAsync();
}
