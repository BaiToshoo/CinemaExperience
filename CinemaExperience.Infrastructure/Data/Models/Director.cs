using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants.Director;

namespace CinemaExperience.Infrastructure.Data.Models;

public class Director
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    [Comment("The name of the director")]
    public string Name { get; set; } = null!;

    [Required]
    [Comment("The birth date of the director")]
    public DateTime BirthDate { get; set; }

    [Required]
    [MaxLength(BiographyMaxLength)]
    [Comment("The biography of the director")]
    public string Biography { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = null!;

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}