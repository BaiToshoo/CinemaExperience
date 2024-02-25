using CinemaExperience.infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		return services;
	}
	public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
	{
		var connectionString = config.GetConnectionString("DefaultConnection");
		services.AddDbContext<CinemaExperienceDbContext>(options =>
			options.UseSqlServer(connectionString));

		services.AddDatabaseDeveloperPageExceptionFilter();

		return services;
	}
	public static IServiceCollection AddApplicationIdentityIdentity(this IServiceCollection services, IConfiguration config)
	{
		services.
			 AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
			.AddEntityFrameworkStores<CinemaExperienceDbContext>();

		return services;
	}
}