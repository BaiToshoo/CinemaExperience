using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaExperience.Infrastructure.Data.Models.Seed;
internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        var data = new SeedData();

        builder.HasData(new Genre[] { data.Action, data.Science,data.Drama,data.Thriller,data.Crime,data.SciFi,data.Mystery,data.Adventure });
    }
}

