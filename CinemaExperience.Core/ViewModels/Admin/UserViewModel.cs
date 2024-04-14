using System.ComponentModel.DataAnnotations;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants.CriticConstants;

namespace CinemaExperience.Core.ViewModels.Admin;
public class UserViewModel
{
    public string Id { get; set; }
    [Required]
    [RegularExpression(CriticEmailRegex)]
    public string Email { get; set; }

    public string FullName { get; set; }
    public bool IsCritic { get; set; }
    public bool IsAdmin { get; set; }
}
