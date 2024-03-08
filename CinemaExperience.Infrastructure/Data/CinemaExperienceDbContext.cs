using CinemaExperience.Infrastructure.Data.Models;
using CinemaExperience.Infrastructure.Data.Models.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace CinemaExperience.infrastructure.Data;
public class CinemaExperienceDbContext : IdentityDbContext
{
    public CinemaExperienceDbContext(DbContextOptions<CinemaExperienceDbContext> options)
        : base(options)
    {
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<MovieGenre>()
        .HasKey(mg => new { mg.MovieId, mg.GenreId });

        builder.Entity<MovieActor>()
        .HasKey(ma => new { ma.MovieId, ma.ActorId });

        builder.ApplyConfiguration(new ApplicationUserConfiguration());
        builder.ApplyConfiguration(new ActorConfiguration());
        builder.ApplyConfiguration(new MovieConfiguration());
        builder.ApplyConfiguration(new DirectorConfiguration());
        builder.ApplyConfiguration(new GenreConfiguration());
        builder.ApplyConfiguration(new MovieActorConfiguration());
        builder.ApplyConfiguration(new MovieGenreConfiguration());
        builder.ApplyConfiguration(new ReviewConfiguration());
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}
