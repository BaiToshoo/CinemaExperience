using System.ComponentModel.DataAnnotations;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants.Director;

namespace CinemaExperience.Core.ViewModels.Director;
public class DirectorViewModel
{
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;
}
