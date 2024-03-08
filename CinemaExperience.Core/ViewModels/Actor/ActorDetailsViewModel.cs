using CinemaExperience.Core.ViewModels.Movie;

namespace CinemaExperience.Core.ViewModels.Actor;
public class ActorDetailsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Biography { get; set; }
    public IEnumerable<MovieViewModel> Movies { get; set; }
}
