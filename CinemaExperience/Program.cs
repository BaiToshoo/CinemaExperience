using CinemaExperience.Extensions;
using CinemaExperience.ModelBinders;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentityIdentity(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});


builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
        name: "Areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapControllerRoute(
        name: "Movie Details",
        pattern: "/Movie/Details/{id}/{information}",
        defaults: new { Controller = "Movie", Action = "Details" }
        );
    endpoints.MapControllerRoute(
        name: "Movie Edit",
        pattern: "/Movie/Edit/{id}/{information}",
        defaults: new { Controller = "Movie", Action = "Edit" }
        );
    endpoints.MapControllerRoute(
        name: "Movie Delete",
        pattern: "/Movie/Delete/{id}/{information}",
        defaults: new { Controller = "Movie", Action = "Delete" }
        );

    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.CreateRoles();
await app.RunAsync();
