using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtFusionStudio.Configuration
{
    public class AppRolesAndUsersSeedingTool
    {

        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;


        public AppRolesAndUsersSeedingTool(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task SeedDefaultRolesAndUsersIfEmpty()
        {
            await SeedDefaultRolesIfEmpty();
            await SeedDefaultUsersIfEmpty();
        }

        public async Task SeedDefaultRolesIfEmpty()
        {
            await SeedRoleIfEmpty(AppConfiguration.AdminRole);
            await SeedRoleIfEmpty(AppConfiguration.CustomerRole);
        }

        public async Task SeedRoleIfEmpty(string roleName)
        {
            if (!(await _roleManager.RoleExistsAsync(roleName)))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        public async Task SeedDefaultUsersIfEmpty()
        {
            await SeedDefaultUserIfEmpty(AppConfiguration.DefaultAdminUsername,
                AppConfiguration.DefaultAdminEmail,
                AppConfiguration.AdminRole,
                AppConfiguration.DefaultAdminPass);

            await SeedDefaultUserIfEmpty(AppConfiguration.DefaultCustomerUsername,
                AppConfiguration.DefaultCustomerEmail,
                AppConfiguration.CustomerRole,
                AppConfiguration.DefaultCustomerPass);
        }

        public async Task SeedDefaultUserIfEmpty(string defaultUsername, 
            string defaultEmail, 
            string defaultRole,
            string defaultPassword)
        {
            if (!(_userManager.Users.Any(user => user.UserName == defaultUsername)))
            {

                ApplicationUser user = new ApplicationUser
                {
                    UserName = defaultUsername,
                    Email = defaultEmail,
                };

                await _userManager.CreateAsync(user, defaultPassword);

                await _userManager.AddToRoleAsync(user, defaultRole);
            }
        }
    }
}
