using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ArtFusionStudio.Areas.Admin.Controllers;
using ArtFusionStudio.Configuration;
using ArtFusionStudio.DataAccess.Repository.IRepository;
using ArtFusionStudio.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContextConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    AppRolesAndUsersSeedingTool appRolesAndUsersSeeder = new AppRolesAndUsersSeedingTool(
        scope.ServiceProvider.GetService<RoleManager<IdentityRole>>(),
        scope.ServiceProvider.GetService<UserManager<ApplicationUser>>(),
        scope.ServiceProvider.GetService<ApplicationDbContext>());
    await appRolesAndUsersSeeder.SeedDefaultRolesAndUsersIfEmpty();
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
