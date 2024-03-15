using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaExperience.Infrastructure.Data.Models.Seed;
internal class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        var data = new SeedData();

        builder.HasData(new Director[] { data.ChristopherNolan, data.DenisVilleneuve });
    }
}
