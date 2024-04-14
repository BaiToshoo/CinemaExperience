using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.Services;
using CinemaExperience.Core.ViewModels.Actor;
using CinemaExperience.Core.ViewModels.Movie;
using CinemaExperience.infrastructure.Data;
using CinemaExperience.Infrastructure.Data.Common;
using CinemaExperience.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace CinemaExperience.UnitTests;

[TestFixture]
public class ActorUnitTests
{
    private IRepository repository;
    private IActorService actorService;
    private CinemaExperienceDbContext dbContext;

    [SetUp]
    public void Setup()
    {

        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<MovieUnitTests>()
            .Build();

        var connectionString = configuration.GetConnectionString("TestConnection");

        var contextOptions = new DbContextOptionsBuilder<CinemaExperienceDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        dbContext = new CinemaExperienceDbContext(contextOptions);
        repository = new Repository(dbContext);
        actorService = new ActorService(repository);

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }

    [Test]
    public async Task Test_AddActorAsync_DeleteAsync_And_DeleteConfirmedAsync()
    {
        var actor = new ActorViewModel()
        {
            Id = 16,
            Name = "Test Actor",
            BirthDate = DateTime.UtcNow.AddYears(-30),
            Biography = "Test Biography",
            ImageUrl = "Test ImageUrl",
            MovieIds = new List<int> { 1, 2 }
        };
        await actorService.AddActorAsync(actor);

        var newActor = await repository.GetByIdAsync<Actor>(actor.Id);
        Assert.That(newActor, Is.Not.Null, "Actor was not saved to the database");
        Assert.That(newActor.Name, Is.EqualTo("Test Actor"));
        Assert.That(newActor.BirthDate, Is.EqualTo(actor.BirthDate));
        Assert.That(newActor.Biography, Is.EqualTo("Test Biography"));
        Assert.That(newActor.ImageUrl, Is.EqualTo("Test ImageUrl"));
        Assert.That(newActor.MovieActors.Count, Is.EqualTo(2));

        var deleteForm = await actorService.DeleteAsync(newActor.Id);

        Assert.That(deleteForm, Is.Not.Null, "Delete form is null");
        Assert.That(deleteForm.Name, Is.EqualTo("Test Actor"));

        dbContext.Entry(newActor).State = EntityState.Detached;

        await actorService.DeleteConfirmedAsync(newActor.Id);

        var deletedMovie = await repository.GetByIdAsync<Movie>(newActor.Id);
        Assert.That(deletedMovie, Is.Null, "Actor was not deleted from the database");
    }

    [Test]
    public async Task Test_ActorExistsAsync_ReturnsCorrectResult()
    {
        // Arrange
        var actors = await repository.AllReadOnly<Actor>().ToListAsync();
        Assert.That(actors, Is.Not.Null, "Actors collection is null");

        // Act
        var results = new List<bool>();
        foreach (var actor in actors)
        {
            var result = await actorService.ActorExistsAsync(actor.Id);
            results.Add(result);
        }

        // Assert
        Assert.That(results, Does.Not.Contain(false), "ActorExistsAsync returned false for one or more actors");
    }

    [Test]
    public async Task Test_Actor_EditGetAsync_And_EditPostAsync()
    {
        var actor = await repository.All<Actor>()
            .Include(a => a.MovieActors)
            .FirstOrDefaultAsync();
        Assert.That(actor, Is.Not.Null, "Actor is null");

        var actorForm = await actorService.EditGetAsync(actor.Id);
        Assert.That(actorForm, Is.Not.Null, "ActorForm is null");

        Assert.That(actorForm.Id, Is.EqualTo(actor.Id));
        Assert.That(actorForm.Name, Is.EqualTo(actor.Name));
        Assert.That(actorForm.Biography, Is.EqualTo(actor.Biography));
        Assert.That(actorForm.BirthDate, Is.EqualTo(actor.BirthDate));
        Assert.That(actorForm.ImageUrl, Is.EqualTo(actor.ImageUrl));
        Assert.That(actorForm.MovieIds.Count, Is.EqualTo(actor.MovieActors.Count));


        var editedForm = new ActorViewModel
        {
            Id = actor.Id,
            Name = "Edited Actor",
            BirthDate = DateTime.UtcNow.AddYears(-40),
            Biography = "Edited Biography",
            ImageUrl = "EditedImageUrl",
            MovieIds = new List<int> { 1, 2 }
        };

        await actorService.EditPostAsync(editedForm);

        var editedActor = await repository.GetByIdAsync<Actor>(actor.Id);

        Assert.That(editedActor, Is.Not.Null, "Edited actor is null");
        Assert.That(editedActor.Name, Is.EqualTo(editedForm.Name));
        Assert.That(editedActor.BirthDate, Is.EqualTo(editedForm.BirthDate));
        Assert.That(editedActor.Biography, Is.EqualTo(editedForm.Biography));
        Assert.That(editedActor.ImageUrl, Is.EqualTo(editedForm.ImageUrl));
        Assert.That(editedActor.MovieActors.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task Test_GetAllActorsAsync_ReturnsCorrectNumberOfMovies()
    {
        // Arrange
        var expectedResult = await repository.AllReadOnly<Actor>().CountAsync();

        // Act
        var result = await actorService.GetAllActorsAsync();

        // Assert
        Assert.That(result.Count, Is.EqualTo(expectedResult));

    }

    [Test]
    public async Task Test_GetActorDetailsAsync_ReturnsCorrectResult()
    {
        // Arrange
        var actor = await repository.AllReadOnly<Actor>()
            .Include(a => a.MovieActors)
            .FirstOrDefaultAsync();
        Assert.That(actor, Is.Not.Null, "Actor is null");

        // Act
        var result = await actorService.GetActorDetailsAsync(actor.Id);

        // Assert
        Assert.That(result, Is.Not.Null, "ActorDetailsViewModel is null");
        Assert.That(result.Id, Is.EqualTo(actor.Id));
        Assert.That(result.Name, Is.EqualTo(actor.Name));
        Assert.That(result.BirthDate, Is.EqualTo(actor.BirthDate));
        Assert.That(result.Biography, Is.EqualTo(actor.Biography));
        Assert.That(result.ImageUrl, Is.EqualTo(actor.ImageUrl));
        Assert.That(result.Movies.Count, Is.EqualTo(actor.MovieActors.Count));
    }

    [Test]
    public async Task Test_GetActorsForFormAsync_ReturnsCorrectResult()
    {
        // Arrange
        var expectedResult = await repository.AllReadOnly<Actor>().CountAsync();

        // Act
        var result = await actorService.GetActorsForFormAsync();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(expectedResult));
    }

    [TearDown]
    public void TearDown()
    {
        dbContext.Dispose();
    }
}
