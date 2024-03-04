using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaExperience.Controllers;

[Authorize]
public class BaseController : Controller
{

}
