using CinemaExperience.Core.ViewModels.Movie;
using CinemaExperience.infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaExperience.Controllers;

[Authorize]
public class MovieController : Controller
{
    private readonly CinemaExperienceDbContext context;

    public MovieController(CinemaExperienceDbContext dbContext)
    {
        context = dbContext;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> All()
    {
        //Getting all of the movies from the database
        var allMovies = await context.Movies
            .AsNoTracking()
            .Select(m => new AllMoviesViewModel()
            {

                Id = m.Id,
                Title = m.Title,
                Director = m.Director.Name,
                ImageUrl = m.ImageUrl
            })
            .ToListAsync();

        //Return all of the movies to the view
        return View(allMovies);
    }

}
