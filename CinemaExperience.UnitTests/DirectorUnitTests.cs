using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.Services;
using CinemaExperience.Infrastructure.Data.Common;
using CinemaExperience.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using CinemaExperience.Core.ViewModels.Director;
using CinemaExperience.Infrastructure.Data.Models;
using CinemaExperience.Core.ViewModels.Actor;

namespace CinemaExperience.UnitTests;

[TestFixture]
public class DirectorUnitTests
{
    private IRepository repository;
    private IDirectorService directorService;
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
        directorService = new DirectorService(repository);

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }

    [Test]
    public async Task Test_AddDirectorAsync_DeleteAsync_And_DeleteConfirmedAsync()
    {
        var director = new DirectorViewModel()
        {
            Id = 3,
            Name = "Test Director",
            BirthDate = DateTime.UtcNow.AddYears(-30),
            Biography = "Test Biography",
            ImageUrl = "Test ImageUrl",
        };
        await directorService.AddDirectorAsync(director);

        var newDirector = await repository.GetByIdAsync<Director>(director.Id);
        Assert.That(newDirector, Is.Not.Null, "Director was not saved to the database");
        Assert.That(newDirector.Name, Is.EqualTo("Test Director"));
        Assert.That(newDirector.BirthDate, Is.EqualTo(director.BirthDate));
        Assert.That(newDirector.Biography, Is.EqualTo("Test Biography"));
        Assert.That(newDirector.ImageUrl, Is.EqualTo("Test ImageUrl"));

        var deleteForm = await directorService.DeleteAsync(newDirector.Id);

        Assert.That(deleteForm, Is.Not.Null, "Delete form is null");
        Assert.That(deleteForm.Name, Is.EqualTo("Test Director"));

        dbContext.Entry(newDirector).State = EntityState.Detached;

        await directorService.DeleteConfirmedAsync(newDirector.Id);

        var deletedDirector = await repository.GetByIdAsync<Director>(newDirector.Id);
        Assert.That(deletedDirector, Is.Null, "Director was not deleted from the database");
    }

    [Test]
    public async Task Test_DirectorExistsAsync_ReturnsCorrectResult()
    {
        // Arrange
        var directors = await repository.AllReadOnly<Director>().ToListAsync();
        Assert.That(directors, Is.Not.Null, "Directors collection is null");

        // Act
        var results = new List<bool>();
        foreach (var actor in directors)
        {
            var result = await directorService.DirectorExistsAsync(actor.Id);
            results.Add(result);
        }

        // Assert
        Assert.That(results, Does.Not.Contain(false), "DirectorExistsAsync returned false for one or more directors");
    }

    [Test]
    public async Task Test_Actor_EditGetAsync_And_EditPostAsync()
    {
        var director = await repository.All<Director>()
            .FirstOrDefaultAsync();
        Assert.That(director, Is.Not.Null, "Director is null");

        var directorForm = await directorService.EditGetAsync(director.Id);
        Assert.That(directorForm, Is.Not.Null, "DirectorForm is null");

        Assert.That(directorForm.Id, Is.EqualTo(director.Id));
        Assert.That(directorForm.Name, Is.EqualTo(director.Name));
        Assert.That(directorForm.Biography, Is.EqualTo(director.Biography));
        Assert.That(directorForm.BirthDate, Is.EqualTo(director.BirthDate));
        Assert.That(directorForm.ImageUrl, Is.EqualTo(director.ImageUrl));


        var editedForm = new DirectorViewModel
        {
            Id = director.Id,
            Name = "Edited Director",
            BirthDate = DateTime.UtcNow.AddYears(-40),
            Biography = "Edited Biography",
            ImageUrl = "EditedImageUrl",
        };

        await directorService.EditPostAsync(editedForm);

        var editedActor = await repository.GetByIdAsync<Director>(director.Id);

        Assert.That(editedActor, Is.Not.Null, "Edited actor is null");
        Assert.That(editedActor.Name, Is.EqualTo(editedForm.Name));
        Assert.That(editedActor.BirthDate, Is.EqualTo(editedForm.BirthDate));
        Assert.That(editedActor.Biography, Is.EqualTo(editedForm.Biography));
        Assert.That(editedActor.ImageUrl, Is.EqualTo(editedForm.ImageUrl));
    }

    [Test]
    public async Task Test_GetAllDirectorsAsync_ReturnsCorrectNumberOfMovies()
    {
        // Arrange
        var expectedResult = await repository.AllReadOnly<Director>().CountAsync();

        // Act
        var result = await directorService.GetAllDirectorsAsync();

        // Assert
        Assert.That(result.Count, Is.EqualTo(expectedResult));

    }

    [Test]
    public async Task Test_GetDirectorsForFormAsync_ReturnsCorrectResult()
    {
        // Arrange
        var expectedResult = await repository.AllReadOnly<Director>().CountAsync();

        // Act
        var result = await directorService.GetDirectorsForFormAsync();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(expectedResult));
    }

    [Test]
    public async Task Test_GetDirectorDetailsAsync_ReturnsCorrectResult()
    {
        // Arrange
        var director = await repository.AllReadOnly<Director>()
            .FirstOrDefaultAsync();
        Assert.That(director, Is.Not.Null, "Director is null");

        // Act
        var result = await directorService.GetDirectorDetailsAsync(director.Id);

        // Assert
        Assert.That(result, Is.Not.Null, "DirectorDetailsViewModel is null");
        Assert.That(result.Id, Is.EqualTo(director.Id));
        Assert.That(result.Name, Is.EqualTo(director.Name));
        Assert.That(result.BirthDate, Is.EqualTo(director.BirthDate));
        Assert.That(result.Biography, Is.EqualTo(director.Biography));
        Assert.That(result.ImageUrl, Is.EqualTo(director.ImageUrl));
    }


    [TearDown]
    public void TearDown()
    {
        dbContext.Dispose();
    }
}
