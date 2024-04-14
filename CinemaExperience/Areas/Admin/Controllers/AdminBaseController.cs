using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CinemaExperience.Infrastructure.Data.Constants.RoleConstants;

namespace CinemaExperience.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = AdminRoleName)]
public class AdminBaseController : Controller
{
}
