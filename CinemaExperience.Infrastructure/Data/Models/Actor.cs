using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants.Actor;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants;

namespace CinemaExperience.Infrastructure.Data.Models;

public class Actor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    [Comment("The name of the actor")]
    public string Name { get; set; } = null!;

    [Required]
    [Comment("The birth date of the actor")]
    public DateTime BirthDate { get; set; }

    [Required]
    [MaxLength(BiographyMaxLength)]
    [Comment("The biography of the actor")]
    public string Biography { get; set; } = null!;

    [Required]
    [MaxLength(ImageUrlMaxLength)]
    public string ImageUrl { get; set; } = null!;

    public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
}