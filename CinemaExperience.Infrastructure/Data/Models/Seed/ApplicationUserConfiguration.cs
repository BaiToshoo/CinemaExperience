using CinemaExperience.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaExperience.Infrastructure.Data.Models.Seed;
internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var data = new SeedData();

        builder.HasData(new ApplicationUser[] { data.AdminUser, data.CriticUser, data.GuestUser, data.DwightBrown, data.KimberlyPierce });
    }
}
