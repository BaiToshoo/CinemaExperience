using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaExperience.infrastructure.Data;
public class CinemaExperienceDbContext : IdentityDbContext
{
	public CinemaExperienceDbContext(DbContextOptions<CinemaExperienceDbContext> options)
		: base(options)
	{
	}
}
