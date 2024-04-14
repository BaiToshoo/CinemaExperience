using CinemaExperience.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants.ApplicationUserConstants;

namespace CinemaExperience.Infrastructure.Identity;
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Required]
    [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
    public string FirstName { get; set; } = null!;

    [PersonalData]
    [Required]
    [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
    public string LastName { get; set; } = null!;
}
