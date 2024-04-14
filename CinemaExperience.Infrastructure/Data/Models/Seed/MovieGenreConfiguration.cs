using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaExperience.Infrastructure.Data.Models.Seed;
internal class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
{
    public void Configure(EntityTypeBuilder<MovieGenre> builder)
    {
        var data = new SeedData();

        builder.HasData(data.TheDarkKnightMovieGenres.ToArray());
        builder.HasData(data.InceptionMovieGenres.ToArray());
        builder.HasData(data.DunePartTwoMovieGenres.ToArray());

    }
}
