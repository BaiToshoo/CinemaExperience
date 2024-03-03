using CinemaExperience.Infrastructure.Data.Models;

namespace CinemaExperience.Core.ViewModels.Movie;
public class MovieDetailsViewModel
{
    public int Id { set; get; }
    public string Title { set; get; }
    public string Director { set; get; }
    public DateTime ReleaseDate { set; get; }
    public int Duration { set; get; }
    public string Description { set; get; }
    public double CriticsRating { set; get; }
    public double UserRating { set; get; }
    public string ImageUrl { set; get; }
    public IEnumerable<Genre> Genres { set; get; }
    public IEnumerable<Actor> Actors { set; get; }

}
