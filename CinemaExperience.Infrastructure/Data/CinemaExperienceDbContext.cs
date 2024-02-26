using CinemaExperience.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

        base.OnModelCreating(builder);
    }
}
