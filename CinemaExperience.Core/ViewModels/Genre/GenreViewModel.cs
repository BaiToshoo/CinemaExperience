using System.ComponentModel.DataAnnotations;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants.Genre;

namespace CinemaExperience.Core.ViewModels.Genre;
public class GenreViewModel
{
    public int Id { get; set; }
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;
}
