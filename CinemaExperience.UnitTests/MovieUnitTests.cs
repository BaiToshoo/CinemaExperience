using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.Services;
using CinemaExperience.Core.ViewModels.Movie;
using CinemaExperience.infrastructure.Data;
using CinemaExperience.Infrastructure.Data.Common;
using CinemaExperience.Infrastructure.Data.Models;
using CinemaExperience.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace CinemaExperience.UnitTests;

[TestFixture]
public class MovieUnitTests
{
    private IRepository repository;
    private IMovieService movieService;
    private CinemaExperienceDbContext dbContext;
    private Mock<UserManager<ApplicationUser>> mockUserManager;


    [SetUp]
    public void Setup()
    {
        var mockUserStore = new Mock<IUserStore<ApplicationUser>>();
        mockUserManager = new Mock<UserManager<ApplicationUser>>(mockUserStore.Object, null, null, null, null, null, null, null, null);

        mockUserManager.Setup(x => x.IsInRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
       .ReturnsAsync((ApplicationUser user, string role) => role == "Critic" || role == "Admin");


        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<MovieUnitTests>()
            .Build();

        var connectionString = configuration.GetConnectionString("TestConnection");

        var contextOptions = new DbContextOptionsBuilder<CinemaExperienceDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        dbContext = new CinemaExperienceDbContext(contextOptions);
        repository = new Repository(dbContext);
        movieService = new MovieService(repository, mockUserManager.Object);

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }

    [Test]
    public async Task Test_Movie_EditGetAsync_And_EditPostAsync()
    {
        var movie = await repository.All<Movie>()
            .Include(m => m.MovieGenres)
            .Include(m => m.MovieActors)
            .FirstOrDefaultAsync();
        Assert.That(movie, Is.Not.Null, "Movie is null");

        var movieForm = await movieService.EditGetAsync(movie.Id);
        Assert.That(movieForm, Is.Not.Null, "MovieForm is null");

        Assert.That(movieForm.Id, Is.EqualTo(movie.Id));
        Assert.That(movieForm.Title, Is.EqualTo(movie.Title));
        Assert.That(movieForm.DirectorId, Is.EqualTo(movie.DirectorId));
        Assert.That(movieForm.ReleaseDate, Is.EqualTo(movie.ReleaseDate));
        Assert.That(movieForm.Duration, Is.EqualTo(movie.Duration));
        Assert.That(movieForm.Description, Is.EqualTo(movie.Description));
        Assert.That(movieForm.ImageUrl, Is.EqualTo(movie.ImageUrl));
        Assert.That(movieForm.GenreIds, Is.EqualTo(movie.MovieGenres.Select(mg => mg.GenreId)));
        Assert.That(movieForm.ActorIds, Is.EqualTo(movie.MovieActors.Select(ma => ma.ActorId)));



        var editedForm = new MovieViewModel
        {
            Id = movie.Id,
            Title = "Edited Movie",
            DirectorId = 1,
            ReleaseDate = DateTime.Now,
            Duration = 120,
            Description = "Edited Description",
            ImageUrl = "EditedImageUrl",
        };

        await movieService.EditPostAsync(editedForm);

        var editedMovie = await repository.GetByIdAsync<Movie>(movie.Id);

        Assert.That(editedMovie, Is.Not.Null, "Movie is null");
        Assert.That(editedMovie.Title, Is.EqualTo("Edited Movie"));
        Assert.That(editedMovie.Description, Is.EqualTo("Edited Description"));
        Assert.That(editedMovie.ImageUrl, Is.EqualTo("EditedImageUrl"));
        Assert.That(editedMovie.DirectorId, Is.EqualTo(editedForm.DirectorId));
        Assert.That(editedMovie.ReleaseDate, Is.EqualTo(editedForm.ReleaseDate));
        Assert.That(editedMovie.Duration, Is.EqualTo(editedForm.Duration));
    }

    [Test]
    public async Task Test_Movie_DeleteAsync_DeleteConfirmedAsync_And_AddMovieAsync()
    {
        var movie = new MovieViewModel
        {
            Id = 4,
            Title = "Test Movie",
            DirectorId = 1,
            ReleaseDate = DateTime.Now,
            Duration = 120,
            Description = "Test Description",
            ImageUrl = "ImageUrl",
            GenreIds = new List<int> { 1, 2 },
            ActorIds = new List<int> { 1, 2 },

        };
        await movieService.AddMovieAsync(movie);

        var newMovieInDb = await repository.GetByIdAsync<Movie>(movie.Id);
        Assert.That(newMovieInDb, Is.Not.Null, "Movie was not saved to the database");
        Assert.That(newMovieInDb.Title, Is.EqualTo(movie.Title));
        Assert.That(newMovieInDb.ReleaseDate, Is.EqualTo(movie.ReleaseDate));
        Assert.That(newMovieInDb.Duration, Is.EqualTo(120));
        Assert.That(newMovieInDb.Description, Is.EqualTo(movie.Description));
        Assert.That(newMovieInDb.ImageUrl, Is.EqualTo(movie.ImageUrl));
        Assert.That(newMovieInDb.MovieGenres.Count, Is.EqualTo(2));
        Assert.That(newMovieInDb.MovieActors.Count, Is.EqualTo(2));


        var deleteForm = await movieService.DeleteAsync(newMovieInDb.Id);

        Assert.That(deleteForm, Is.Not.Null, "Delete form is null");
        Assert.That(deleteForm.Title, Is.EqualTo("Test Movie"));

        dbContext.Entry(newMovieInDb).State = EntityState.Detached;

        await movieService.DeleteConfirmedAsync(newMovieInDb.Id);

        var deletedMovie = await repository.GetByIdAsync<Movie>(newMovieInDb.Id);
        Assert.That(deletedMovie, Is.Null, "Movie was not deleted from the database");

    }

    [Test]
    public async Task Test_GetAllMoviesAsync_ReturnsCorrectNumberOfMovies()
    {
        // Arrange
        var expectedResult = await repository.AllReadOnly<Movie>().CountAsync();

        // Act
        var result = await movieService.GetAllMoviesAsync();

        // Assert
        Assert.That(result.Count, Is.EqualTo(expectedResult));

    }

    [Test]
    public async Task Test_GetMovieDetailsAsync_ReturnsCorrectMovieDetails()
    {
        // Arrange
        var movie = repository.AllReadOnly<Movie>()
            .Include(m => m.Director)
            .Include(m => m.MovieGenres).ThenInclude(g => g.Genre)
            .Include(m => m.MovieActors).ThenInclude(a => a.Actor)
            .FirstOrDefault();
        Assert.That(movie, Is.Not.Null, "Movie is null");

        // Act
        var result = await movieService.GetMovieDetailsAsync(movie.Id);

        var criticReviews = new List<Review>();
        var audienceReviews = new List<Review>();


        //foreach (var review in movie.Reviews)
        //{
        //    if (await userManager.IsInRoleAsync(review.User, "Critic"))
        //    {
        //        criticReviews.Add(review);
        //    }
        //    else if (await userManager.IsInRoleAsync(review.User, "Guest"))
        //    {
        //        audienceReviews.Add(review);
        //    }
        //}

        //var criticScore = criticReviews.Any()
        //    ? movie.Reviews.Average(r => r.Rating) * 10 : 0;

        //var audienceScore = audienceReviews.Any()
        //    ? movie.Reviews.Average(r => r.Rating) * 10 : 0;

        // Assert
        Assert.That(result, Is.Not.Null, "Movie details are null");
        Assert.That(result.Id, Is.EqualTo(movie.Id));
        Assert.That(result.Title, Is.EqualTo(movie.Title));
        Assert.That(result.Director, Is.EqualTo(movie.Director.Name));
        Assert.That(result.ReleaseDate, Is.EqualTo(movie.ReleaseDate));
        Assert.That(result.Duration, Is.EqualTo(movie.Duration));
        Assert.That(result.Description, Is.EqualTo(movie.Description));
        Assert.That(result.ImageUrl, Is.EqualTo(movie.ImageUrl));
        Assert.That(result.Genres.Select(g => g.Name), Is.EqualTo(movie.MovieGenres.Select(mg => mg.Genre.Name)));
        Assert.That(result.Actors.Select(a => a.Name), Is.EqualTo(movie.MovieActors.Select(ma => ma.Actor.Name)));
        //Assert.That(result.CriticsRating, Is.EqualTo(criticScore));
        //Assert.That(result.UserRating, Is.EqualTo(audienceScore));
    }

    [Test]
    public async Task Test_MovieExistsAsync_ReturnsCorrectResult()
    {
        // Arrange
        var movie = repository.AllReadOnly<Movie>().FirstOrDefault();
        Assert.That(movie, Is.Not.Null, "Movie is null");

        // Act
        var result = await movieService.MovieExistsAsync(movie.Id);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public async Task Test_GetMoviesForFormAsync_ReturnsCorrectNumberOfMovies()
    {
        // Arrange
        var expectedResult = await repository.AllReadOnly<Movie>().CountAsync();

        // Act
        var result = await movieService.GetMoviesForFormAsync();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(expectedResult));
    }

    [Test]
    public async Task Test_GetGenresForFormAsync_ReturnsCorrectNumberOfGenres()
    {
        // Arrange
        var expectedResult = await repository.AllReadOnly<Genre>().CountAsync();

        // Act
        var result = await movieService.GetGenresForFormAsync();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(expectedResult));
    }

    [Test]
    public async Task Test_GenresExistsAsync_ReturnsCorrectResult()
    {
        // Arrange
        var genres = await repository.AllReadOnly<Genre>().ToListAsync();
        Assert.That(genres, Is.Not.Null, "Genres collection is null");
        var results = new List<bool>();

        // Act
        foreach (var genre in genres)
        {
            var result = await movieService.GenreExistsAsync(genre.Id);
            results.Add(result);
        }

        // Assert
        Assert.That(results, Does.Not.Contain(false), "GenreExistsAsync returned false for one or more genres");
    }

    [Test]
    public async Task Test_SearchAsync_ReturnsCorrectMovies()
    {
        // Arrange
        var movies = await repository.AllReadOnly<Movie>().ToListAsync();
        Assert.That(movies, Is.Not.Null, "Movies collection is null");
        var input = "d";
        var expectedResults = movies.Where(m => m.Title.ToLower().Contains(input.ToLower()));

        // Act
        var result = await movieService.SearchAsync(input);

        // Assert
        Assert.That(result.Count(), Is.EqualTo(expectedResults.Count()));
    }

    [TearDown]
    public void TearDown()
    {
        dbContext.Dispose();
    }



}
