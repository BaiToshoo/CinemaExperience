using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants.Movie;

namespace CinemaExperience.Infrastructure.Data.Models;
public class Movie
{
    [Key]
    [Comment("The unique identifier for the movie")]
    public int Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    [Comment("The title of the movie")]
    public string Title { get; set; } = null!;

    [Required]
    [Comment("The director of the movie")]
    public int DirectorId { get; set; }

    [ForeignKey(nameof(DirectorId))]
    public Director Director { get; set; } = null!;

    [Required]
    [Comment("The release date of the movie")]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [Comment("The duration of the movie in minutes")]
    public int Duration { get; set; }

    [Required]
    public string ImageUrl { get; set; } = null!;

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<MovieActor> Actors { get; set; } = new List<MovieActor>();
    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
}
