using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaExperience.Infrastructure.Data.Models.Seed;
internal class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        var data = new SeedData();

        builder.HasData(new Actor[] { data.ChristianBale, data.HeathLedger, data.MichaelCaine, data.AaronEckhart, data.MaggieGyllenhaal, data.LeonardoDiCaprio, data.JosephGordonLevitt, data.ElliotPage, data.TomHardy, data.KenWatanabe, data.TimotheeChalamet, data.Zendaya, data.RebeccaFerguson, data.JavierBardem, data.AustinButler });
    }
}
