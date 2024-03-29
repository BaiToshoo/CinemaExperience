using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Review;

namespace CinemaExperience.Core.ViewModels.Movie;
public class MovieDetailsViewModel : IMovieModel
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
    public IEnumerable<Infrastructure.Data.Models.Genre> Genres { set; get; } = new List<Infrastructure.Data.Models.Genre>();
    public IEnumerable<Infrastructure.Data.Models.Actor> Actors { set; get; } = new List<Infrastructure.Data.Models.Actor>();
    public IEnumerable<ReviewViewModel> LatestReviews { set; get; } = new List<ReviewViewModel>();

}
