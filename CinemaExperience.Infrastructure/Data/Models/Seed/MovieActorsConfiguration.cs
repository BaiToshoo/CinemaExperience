using Microsoft.EntityFrameworkCore;

namespace CinemaExperience.Infrastructure.Data.Models.Seed;
internal class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MovieActor> builder)
    {
        var data = new SeedData();

        builder.HasData(data.TheDarkKnightMovieActors.ToArray());
        builder.HasData(data.InceptionMovieActors.ToArray());
        builder.HasData(data.DunePartTwoMovieActors.ToArray());

    }
}
