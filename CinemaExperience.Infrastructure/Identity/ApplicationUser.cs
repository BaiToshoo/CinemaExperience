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

    //Collection of reviews that the user has made
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();


    //Distinguishes between regular user and critic
    public bool IsCritic { get; set; } = false;

    //Distinguishes between regular user or critic and admin
    public bool IsAdmin { get; set; } = false;
}
