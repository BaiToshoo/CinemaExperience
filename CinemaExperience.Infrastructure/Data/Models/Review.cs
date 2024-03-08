using CinemaExperience.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants.Review;

namespace CinemaExperience.Infrastructure.Data.Models;
public class Review
{
    [Key]
    [Comment("The unique identifier for the review")]
    public int Id { get; set; }

    [Required]
    public int MovieId { get; set; }

    [ForeignKey(nameof(MovieId))]
    public Movie Movie { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;

    [Required]
    [MaxLength(ContentMaxLength)]
    [Comment("The content of the review")]
    public string Content { get; set; } = null!;

    [Required]
    [Range(MinRating, MaxRating)]
    [Comment("The rating of the review in pattern 1-10")]
    public int Rating { get; set; }

    [Required]
    [Comment("The date when the review was posted")]
    public DateTime PostedOn { get; set; }
}
