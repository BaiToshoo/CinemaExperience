﻿using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Actor;
using CinemaExperience.Core.ViewModels.Director;
using CinemaExperience.Core.ViewModels.Genre;
using CinemaExperience.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants;
using static CinemaExperience.Infrastructure.Data.Constants.DataConstants.Movie;
namespace CinemaExperience.Core.ViewModels.Movie;
public class MovieViewModel: IMovieModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = LengthErrorMessage)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [Display(Name = "Director")]
    public int DirectorId { get; set; }
    public IEnumerable<DirectorFormViewModel> Directors { get; set; } = new List<DirectorFormViewModel>();

    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [Display(Name = "Genre")]
    public IEnumerable<int> GenreIds { get; set; } = new List<int>();
    public IEnumerable<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();

    [Display(Name = "Actors")]
    public IEnumerable<int> ActorIds { get; set; } = new List<int>();
    public IEnumerable<ActorFormViewModel> Actors { get; set; } = new List<ActorFormViewModel>();

    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [DisplayFormat(DataFormatString = Dateformat)]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [Range(MinDuration, MaxDuration, ErrorMessage = RangeErrorMessage)]
    public int Duration { get; set; }

    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
    [Display(Name = "Image URL")]
    public string ImageUrl { get; set; } = "/images/movies/";

}
