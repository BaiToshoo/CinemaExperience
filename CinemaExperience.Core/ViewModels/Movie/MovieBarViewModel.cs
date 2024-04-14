using CinemaExperience.Core.Contracts;

namespace CinemaExperience.Core.ViewModels.Movie;
public class MovieBarViewModel : IMovieModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
}
