using CinemaExperience.Core.Contracts;
using CinemaExperience.Core.Services;
using CinemaExperience.infrastructure.Data;
using CinemaExperience.Infrastructure.Data.Common;
using CinemaExperience.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IActorService, ActorService>();
        services.AddScoped<IDirectorService, DirectorService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAdminService, AdminService>();

        return services;
    }
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<CinemaExperienceDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IRepository, Repository>();

        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }
    public static IServiceCollection AddApplicationIdentityIdentity(this IServiceCollection services, IConfiguration config)
    {
        services.
             AddDefaultIdentity<ApplicationUser>(options =>
             {
                 options.SignIn.RequireConfirmedAccount = false;
                 options.Password.RequireDigit = false;
                 options.Password.RequireNonAlphanumeric = false;
                 options.Password.RequireUppercase = false;
             })
             .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CinemaExperienceDbContext>();

        return services;
    }
}