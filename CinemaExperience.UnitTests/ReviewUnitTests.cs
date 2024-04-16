using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.Services;
using CinemaExperience.Core.ViewModels.Review;
using CinemaExperience.infrastructure.Data;
using CinemaExperience.Infrastructure.Data.Common;
using CinemaExperience.Infrastructure.Data.Models;
using CinemaExperience.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using static CinemaExperience.Infrastructure.Data.Constants.RoleConstants;

namespace CinemaExperience.UnitTests;

[TestFixture]
public class ReviewUnitTests
{
    private IRepository repository;
    private IReviewService reviewService;
    private CinemaExperienceDbContext dbContext;
    private Mock<UserManager<ApplicationUser>> mockUserManager;


    [SetUp]
    public void Setup()
    {
        var mockUserStore = new Mock<IUserStore<ApplicationUser>>();
        mockUserManager = new Mock<UserManager<ApplicationUser>>(mockUserStore.Object, null, null, null, null, null, null, null, null);

        mockUserManager.Setup(x => x.IsInRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
       .ReturnsAsync((ApplicationUser user, string role) => role == CriticRoleName || role == AdminRoleName);

        mockUserManager.Setup(x => x.GetRolesAsync(It.IsAny<ApplicationUser>()))
            .ReturnsAsync(new List<string> { CriticRoleName });

        mockUserManager.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new ApplicationUser());


        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<ReviewUnitTests>()
            .Build();

        var connectionString = configuration.GetConnectionString("TestConnection");

        var contextOptions = new DbContextOptionsBuilder<CinemaExperienceDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        dbContext = new CinemaExperienceDbContext(contextOptions);
        repository = new Repository(dbContext);
        reviewService = new ReviewService(repository, mockUserManager.Object);

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }

    [Test]
    public async Task Test_AddReviewAsync_DeleteAsync_And_DeleteConfirmedAsync()
    {
        var maxReviewId = await repository.AllReadOnly<Review>().MaxAsync(r => r.Id);
        var review = new ReviewViewModel()
        {
            Id = maxReviewId + 1,
            Content = "Test Content",
            Rating = 5,
            MovieId = 1,
            UserId = "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5"
        };
        await reviewService.AddReviewAsync(review);

        var newReview = await repository.GetByIdAsync<Review>(review.Id);
        Assert.That(newReview, Is.Not.Null, "Review was not saved to the database");
        Assert.That(newReview.Content, Is.EqualTo("Test Content"));
        Assert.That(newReview.Rating, Is.EqualTo(5));
        Assert.That(newReview.MovieId, Is.EqualTo(1));
        Assert.That(newReview.UserId, Is.EqualTo(review.UserId));

        var deleteForm = await reviewService.DeleteAsync(newReview.Id);
        Assert.That(deleteForm, Is.Not.Null, "Delete form is null");
        Assert.That(deleteForm.Content, Is.EqualTo("Test Content"));

        dbContext.Entry(newReview).State = EntityState.Detached;

        await reviewService.DeleteConfirmedAsync(newReview.Id);

        var deletedReview = await repository.GetByIdAsync<Review>(newReview.Id);
        Assert.That(deletedReview, Is.Null, "Review was not deleted from the database");
    }

    [Test]
    public async Task Test_Review_EditGetAsync_And_EditPostAsync()
    {
        var review = await repository.All<Review>()
            .Include(r => r.Movie)
            .Include(r => r.User)
            .FirstOrDefaultAsync();
        Assert.That(review, Is.Not.Null, "Review is null");

        var reviewForm = await reviewService.EditReviewGetAsync(review.Id);
        Assert.That(reviewForm, Is.Not.Null, "Review form is null");

        Assert.That(reviewForm.Content, Is.EqualTo(review.Content));
        Assert.That(reviewForm.Rating, Is.EqualTo(review.Rating));
        Assert.That(reviewForm.MovieId, Is.EqualTo(review.MovieId));
        Assert.That(reviewForm.UserId, Is.EqualTo(review.UserId));

        var editedForm = new ReviewViewModel()
        {
            Id = review.Id,
            Content = "Edited Content",
        };

        await reviewService.EditReviewPostAsync(editedForm);

        var editedReview = await repository.GetByIdAsync<Review>(review.Id);
        Assert.That(editedReview, Is.Not.Null, "Review was not edited");
        Assert.That(editedReview.Content, Is.EqualTo("Edited Content"));
    }

    [Test]
    public async Task Test_ReviewExistsAsync_ReturnsCorrectResult()
    {
        // Arrange
        var reviews = await repository.AllReadOnly<Review>().ToListAsync();
        Assert.That(reviews, Is.Not.Null, "Reviews collection is null");

        // Act
        var results = new List<bool>();
        foreach (var review in reviews)
        {
            var result = await reviewService.ReviewExistsAsync(review.Id);
            results.Add(result);
        }

        // Assert
        Assert.That(results, Does.Not.Contain(false), "ReviewExistsAsync returned false for one or more reviews");
    }

    [Test]
    public async Task Test_GetAllReviewsByMovieIdAsync_ReturnsCorrectResult()
    {
        // Arrange
        var movieId = 1;
        var expectedReviews = await repository.AllReadOnly<Review>()
            .Where(r => r.MovieId == movieId)
            .ToListAsync();

        // Act
        var result = await reviewService.GetAllReviewsByMovieIdAsync(movieId);

        // Assert
        Assert.That(result.Count(), Is.EqualTo(expectedReviews.Count));
        foreach (var review in result)
        {
            var expectedReview = expectedReviews.Single(r => r.Id == review.Id);
            Assert.That(review.Content, Is.EqualTo(expectedReview.Content));
            Assert.That(review.Rating, Is.EqualTo(expectedReview.Rating));
            Assert.That(review.PostedOn, Is.EqualTo(expectedReview.PostedOn));
            Assert.That(review.UserId, Is.EqualTo(expectedReview.UserId));
        }
    }

    [TearDown]
    public void TearDown()
    {
        dbContext.Dispose();
    }
}
