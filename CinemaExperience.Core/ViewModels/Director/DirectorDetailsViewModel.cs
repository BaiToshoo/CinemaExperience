using CinemaExperience.Core.ViewModels.Movie;

namespace CinemaExperience.Core.ViewModels.Director;
public class DirectorDetailsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public IEnumerable<MovieBarViewModel> Movies { get; set; } = new HashSet<MovieBarViewModel>();
}
