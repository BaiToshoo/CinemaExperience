using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.Services;
using CinemaExperience.infrastructure.Data;
using CinemaExperience.Infrastructure.Data.Common;
using CinemaExperience.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using static CinemaExperience.Infrastructure.Data.Constants.RoleConstants;

namespace CinemaExperience.UnitTests;

[TestFixture]
public class UserUnitTests
{
    private IRepository repository;
    private IUserService userService;
    private CinemaExperienceDbContext dbContext;
    private Mock<UserManager<ApplicationUser>> mockUserManager;


    [SetUp]
    public void Setup()
    {
        var mockUserStore = new Mock<IUserStore<ApplicationUser>>();
        mockUserManager = new Mock<UserManager<ApplicationUser>>(mockUserStore.Object, null, null, null, null, null, null, null, null);

        mockUserManager.Setup(x => x.IsInRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
       .ReturnsAsync((ApplicationUser user, string role) => role == CriticRoleName || role == AdminRoleName);


        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<UserUnitTests>()
            .Build();

        var connectionString = configuration.GetConnectionString("TestConnection");

        var contextOptions = new DbContextOptionsBuilder<CinemaExperienceDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        dbContext = new CinemaExperienceDbContext(contextOptions);
        repository = new Repository(dbContext);
        userService = new UserService(repository, mockUserManager.Object);

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }

    [Test]
    public async Task Test_ExistsByEmailAsync_ReturnsCorrectResult()
    {
        // Arrange
        var email = repository.AllReadOnly<ApplicationUser>().FirstOrDefault().Email;
        Assert.That(email, Is.Not.Null, "Email is null");

        // Act
        var result = await userService.ExistsByEmailAsync(email);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public async Task Test_ExistsByIdAsync_ReturnsCorrectResult()
    {
        // Arrange
        var userId = repository.AllReadOnly<ApplicationUser>().FirstOrDefault().Id;
        Assert.That(userId, Is.Not.Null, "UserId is null");

        // Act
        var result = await userService.ExistsByIdAsync(userId);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public async Task Test_GetUserByEmailAsync_ReturnsCorrectUser()
    {
        // Arrange
        var email = repository.AllReadOnly<ApplicationUser>().FirstOrDefault().Email;
        Assert.That(email, Is.Not.Null, "Email is null");

        // Act
        var user = await userService.GetUserByEmailAsync(email);

        // Assert
        Assert.That(user, Is.Not.Null);
        Assert.That(user.Email, Is.EqualTo(email));
    }

    [Test]
    public async Task Test_GetUserByIdAsync_ReturnsCorrectUser()
    {
        // Arrange
        var userId = repository.AllReadOnly<ApplicationUser>().FirstOrDefault().Id;
        Assert.That(userId, Is.Not.Null, "UserId is null");

        // Act
        var user = await userService.GetUserByIdAsync(userId);

        // Assert
        Assert.That(user, Is.Not.Null);
        Assert.That(user.Id, Is.EqualTo(userId));
    }

    [Test]
    public async Task Test_GetAllUsersAsync_ReturnsCorrectResult()
    {
        // Arrange
        var expectedUsers = await repository.AllReadOnly<ApplicationUser>().ToListAsync();
        Assert.That(expectedUsers, Is.Not.Null, "Users collection is null");

        // Act
        var result = await userService.GetAllUsersAsync(1, 10);

        // Assert
        Assert.That(result.Items.Count, Is.EqualTo(expectedUsers.Count));
        foreach (var user in result.Items)
        {
            var expectedUser = expectedUsers.Single(u => u.Id == user.Id);
            Assert.That(user.Email, Is.EqualTo(expectedUser.Email));
            Assert.That(user.FullName, Is.EqualTo(expectedUser.FirstName + " " + expectedUser.LastName));
        }
    }
    [Test]
    public async Task Test_IsCriticAsync_ReturnsCorrectResult()
    {
        // Arrange
        var criticEmail = "critic@critic.com";
        var userId = repository.AllReadOnly<ApplicationUser>().Where(u => u.Email == criticEmail)
            .FirstOrDefault().Id;
        Assert.That(userId, Is.Not.Null, "UserId is null");


        // Act
        var result = await userService.IsCriticAsync(userId);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public async Task Test_IsAdminAsync_ReturnsCorrectResult()
    {
        // Arrange
        var adminEmail = "admin@admin.com";
        var userId = repository.AllReadOnly<ApplicationUser>().Where(u => u.Email == adminEmail)
            .FirstOrDefault().Id;
        Assert.That(userId, Is.Not.Null, "UserId is null");

        // Act
        var result = await userService.IsAdminAsync(userId);

        // Assert
        Assert.That(result, Is.True);
    }


}
