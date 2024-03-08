using System.ComponentModel.DataAnnotations;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants.Director;
namespace CinemaExperience.Core.ViewModels.Director;
public class AddDirectorViewModel
{
    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = LengthErrorMessage)]
    public string Name { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Birth Date")]
    [DisplayFormat(DataFormatString = Dateformat)]
    public DateTime BirthDate { get; set; }

    [Required]
    [Display(Name = "Image URL")]
    [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
    public string ImageUrl { get; set; } = "/images/directors/";

    [Required]
    [StringLength(BiographyMaxLength, MinimumLength = BiographyMinLength, ErrorMessage = LengthErrorMessage)]
    public string Biography { get; set; } = null!;
}
