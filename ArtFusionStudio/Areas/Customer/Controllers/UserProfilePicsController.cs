using ArtFusionStudio.Areas.Admin.Controllers;
using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace ArtFusionStudio.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class UserProfilePicsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserProfilePicsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserProfilePics/Index
        public async Task<IActionResult> Index()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            var user = await _userManager.GetUserAsync(User);

            var userProfilePic = await _context.UserProfilePics
                .FirstOrDefaultAsync(p => p.UserId == user.Id);

            return View(userProfilePic);
        }

        // GET: UserProfilePics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserProfilePics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var user = await _userManager.GetUserAsync(User);

            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            var userProfilePic = new UserProfilePic
            {
                UserId = user.Id,
                FileExtension = fileExtension 
            };

            var imagePath = Path.Combine("wwwroot/images/profiles/", $"{user.Id}{fileExtension}");
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _context.UserProfilePics.Add(userProfilePic);
            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction(nameof(Index));
        }

        // GET: UserProfilePics/Edit
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);

            var userProfilePic = await _context.UserProfilePics
                .FirstOrDefaultAsync(p => p.UserId == user.Id);
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(userProfilePic);
        }


        // POST: UserProfilePics/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            // Retrieve the current user
            var user = await _userManager.GetUserAsync(User);

            // Get the user's existing profile picture, if it exists
            var userProfilePic = await _context.UserProfilePics
                .FirstOrDefaultAsync(p => p.UserId == user.Id);

            if (userProfilePic != null)
            {
                // Remove the existing profile picture file by name only (excluding extension)
                var existingImagePath = Path.Combine("wwwroot/images/profiles", $"{user.Id}*");
                var existingFiles = Directory.GetFiles("wwwroot/images/profiles", $"{user.Id}*");
                foreach (var existingFile in existingFiles)
                {
                    System.IO.File.Delete(existingFile);
                }

                // Save the new profile picture
                var imageExt = Path.GetExtension(file.FileName);
                var imageExtension = new ImageExtension { Extension = imageExt };
                _context.ImageExtensions.Add(imageExtension);
                await _context.SaveChangesAsync();

                var newImagePath = Path.Combine("wwwroot/images/profiles", $"{user.Id}{imageExt}");
                using (var stream = new FileStream(newImagePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                userProfilePic.FileExtension = imageExtension.Extension;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
