using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaExperience.Infrastructure.Data.Models.Seed;
internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        var data = new SeedData();

        builder.HasData(new Review[] { data.Review1, data.Review2, data.Review3, data.Review4 });
    }
}
