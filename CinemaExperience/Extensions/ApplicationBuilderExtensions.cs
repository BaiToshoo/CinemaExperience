using CinemaExperience.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using static CinemaExperience.Infrastructure.Data.Constants.RoleConstants;

namespace CinemaExperience.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder CreateRoles(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var serviceProvider = serviceScope.ServiceProvider;
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            CreateRoleAndAssignToUser(roleManager, userManager, AdminRoleName, "admin@admin.com").GetAwaiter().GetResult();
            CreateRoleAndAssignToUser(roleManager, userManager, UserRoleName, "guest@guest.com").GetAwaiter().GetResult();
            CreateRoleAndAssignToUser(roleManager, userManager, CriticRoleName, "critic@critic.com").GetAwaiter().GetResult();
            CreateRoleAndAssignToUser(roleManager, userManager, UserRoleName, "kimberly@pierce.com").GetAwaiter().GetResult();
            CreateRoleAndAssignToUser(roleManager, userManager, CriticRoleName, "dwight@brown.com").GetAwaiter().GetResult();
        }

        return app;
    }

    private static async Task CreateRoleAndAssignToUser(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, string roleName, string userEmail)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }

        var user = await userManager.FindByEmailAsync(userEmail);
        if (user != null)
        {
            await userManager.AddToRoleAsync(user, roleName);
        }
    }
}
