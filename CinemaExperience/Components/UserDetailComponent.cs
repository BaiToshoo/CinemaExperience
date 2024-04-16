using CinemaExperience.Core.ViewModels.Admin;
using CinemaExperience.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaExperience.Components;

public class UserDetailComponent : ViewComponent
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly SignInManager<ApplicationUser> _signInManager;

	public UserDetailComponent(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		string userFullName = "";
		string userRole = "";

		if (_signInManager.IsSignedIn(HttpContext.User))
		{
			var user = await _userManager.GetUserAsync(HttpContext.User);
			userFullName = $"{user.FirstName} {user.LastName}";
			var roles = await _userManager.GetRolesAsync(user);
			userRole = roles.FirstOrDefault(); // Assuming a user has only one role
		}

		var model = new UserDetailViewModel
		{
			FullName = userFullName,
			Role = userRole
		};

		return await Task.FromResult((IViewComponentResult)View(model));
	}
}
