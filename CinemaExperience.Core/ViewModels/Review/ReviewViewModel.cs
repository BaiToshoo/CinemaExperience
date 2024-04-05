using System.ComponentModel.DataAnnotations;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants.Review;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants;

namespace CinemaExperience.Core.ViewModels.Review;
public class ReviewViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = LengthErrorMessage)]
    public string Content { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [Range(MinRating, MaxRating, ErrorMessage = RangeErrorMessage)]
    public int Rating { get; set; }

    public int MovieId { get; set; }

    public string UserId { get; set; } = null!;
}
