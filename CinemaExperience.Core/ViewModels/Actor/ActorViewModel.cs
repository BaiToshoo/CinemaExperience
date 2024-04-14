using CinemaExperience.Core.ViewModels.Movie;
using System.ComponentModel.DataAnnotations;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants.Actor;

namespace CinemaExperience.Core.ViewModels.Actor;
public class ActorViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = LengthErrorMessage)]
    public string Name { get; set; } = null!;

    [Display(Name = "Movies")]
    public IEnumerable<int> MovieIds { get; set; } = new List<int>();
    public IEnumerable<MovieFormViewModel> Movies { get; set; } = new List<MovieFormViewModel>();

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Birth Date")]
    [DisplayFormat(DataFormatString = Dateformat)]
    public DateTime BirthDate { get; set; }

    [Required]
    [Display(Name = "Image URL")]
    [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
    public string ImageUrl { get; set; } = "/images/actors/";

    [Required]
    [StringLength(BiographyMaxLength, MinimumLength = BiographyMinLength, ErrorMessage = LengthErrorMessage)]
    public string Biography { get; set; } = null!;
}
