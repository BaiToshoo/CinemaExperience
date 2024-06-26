﻿using CinemaExperience.Core.Contracts;

namespace CinemaExperience.Core.ViewModels.Movie;
public class MovieDeleteViewModel : IMovieModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}
