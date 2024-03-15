using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.ViewModels.Director;
using CinemaExperience.Core.ViewModels.Genre;
using CinemaExperience.Core.ViewModels.Movie;
using CinemaExperience.Core.ViewModels.Review;
using CinemaExperience.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CinemaExperience.Core.Services;
public class MovieService : IMovieService
{
    private readonly IRepository repository;

    public MovieService(IRepository _repository)
    {
        repository = _repository;
    }

    public async Task<int> AddMovieAsync(AddMovieViewModel movieForm)
    {

        var movie = new Infrastructure.Data.Models.Movie
        {
            Title = movieForm.Title,
            DirectorId = movieForm.DirectorId,
            ReleaseDate = movieForm.ReleaseDate,
            Duration = movieForm.Duration,
            Description = movieForm.Description,
            ImageUrl = movieForm.ImageUrl,
            MovieGenres = movieForm.GenreIds.Select(g => new Infrastructure.Data.Models.MovieGenre
            {
                GenreId = g
            }).ToList()
        };
        await repository.AddAsync(movie);
        await repository.SaveChangesAsync();

        return movie.Id;
    }

    public async Task<bool> GenreExistsAsync(IEnumerable<int> genreId)
    {
        return await repository.AllReadOnly<Infrastructure.Data.Models.Genre>()
            .AnyAsync(g => genreId.Contains(g.Id));
    }

    public async Task<IEnumerable<AllMoviesViewModel>> GetAllMoviesAsync()
    {
        return await repository.AllReadOnly<Infrastructure.Data.Models.Movie>()
            .Select(m => new AllMoviesViewModel
            {
                Id = m.Id,
                Director = m.Director.Name,
                Title = m.Title,
                ImageUrl = m.ImageUrl
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<DirectorViewModel>> GetDirectorsAsync()
    {
        return await repository.AllReadOnly<Infrastructure.Data.Models.Director>()
             .Select(d => new DirectorViewModel
             {
                 Id = d.Id,
                 Name = d.Name
             })
             .ToListAsync();
    }

    public async Task<IEnumerable<GenreViewModel>> GetGenresAsync()
    {
        return await repository.AllReadOnly<Infrastructure.Data.Models.Genre>()
            .Select(g => new GenreViewModel
            {
                Id = g.Id,
                Name = g.Name
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ReviewViewModel>> GetLatestReviewsAsync(int movieId)
    {
        var latestReviews = await repository.AllReadOnly<Infrastructure.Data.Models.Review>()
            .Where(r => r.MovieId == movieId)
            .OrderByDescending(r => r.PostedOn)
            .Take(2)
            .Select(r => new ReviewViewModel
            {
                Author = r.User.FirstName + " " + r.User.LastName,
                Content = r.Content,
                PostedOn = r.PostedOn,
                Rating = r.Rating,
                IsCriticsReview = r.User.IsCritic
            })
            .ToListAsync();

        return latestReviews;
    }

    public async Task<MovieDetailsViewModel> GetMovieDetailsAsync(int movieId)
    {
        var movie = await repository.AllReadOnly<Infrastructure.Data.Models.Movie>()
            .Include(m => m.Director)
            .Include(m => m.MovieGenres).ThenInclude(g => g.Genre)
            .Include(m => m.MovieActors).ThenInclude(a => a.Actor)
            .Include(m => m.Reviews).ThenInclude(r => r.User)
            .FirstOrDefaultAsync(m => m.Id == movieId);

        if (movie == null)
        {
            return null;
        }

        var criticReviews = movie.Reviews.Where(r => r.User != null && r.User.IsCritic);
        var audianceReviews = movie.Reviews.Where(r => r.User != null && !r.User.IsCritic);

        var criticScore = criticReviews.Any()
            ? movie.Reviews.Average(r => r.Rating) * 10 : 0;

        var audienceScore = audianceReviews.Any()
            ? movie.Reviews.Average(r => r.Rating) * 10 : 0;

        var movieDetails = new MovieDetailsViewModel()
        {

            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director.Name,
            ReleaseDate = movie.ReleaseDate,
            Duration = movie.Duration,
            Description = movie.Description,
            CriticsRating = criticScore,
            UserRating = audienceScore,
            ImageUrl = movie.ImageUrl,
            Genres = movie.MovieGenres.Select(g => g.Genre),
            Actors = movie.MovieActors.Select(a => a.Actor)
        };

        return movieDetails;
    }

    public async Task<IEnumerable<AllMoviesViewModel>> SearchAsync(string input)
    {
        var searchedMovies = await repository.AllReadOnly<Infrastructure.Data.Models.Movie>()
            .Where(m => input.ToLower().Contains(m.Title.ToLower())
            || m.Title.ToLower().Contains(input.ToLower()))
            .Select(m => new AllMoviesViewModel
            {
                Id = m.Id,
                Director = m.Director.Name,
                Title = m.Title,
                ImageUrl = m.ImageUrl
            })
            .ToListAsync();

        return searchedMovies;
    }
}
