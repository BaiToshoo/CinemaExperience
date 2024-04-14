using Microsoft.AspNetCore.Mvc;

namespace CinemaExperience.Areas.Admin.Controllers;
public class HomeController : AdminBaseController
{
    public IActionResult Actions()
    {
        return View();
    }
}
