using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtFusionStudio.Models.ProductFeatures.PhoneAccessories;
using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Configuration;
using ArtFusionStudio.Models;

namespace ArtFusionStudio.Areas.Admin.Controllers.OtherProducts
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CaseTypes
        public async Task<IActionResult> Index()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(await _context.ApplicationUsers.ToListAsync());
        }


        // GET: Admin/CaseTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageExtension = await _context.ImageExtensions
                .FirstOrDefaultAsync(e => e.Id == id);
            if (imageExtension == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(imageExtension);
        }

        // POST: Admin/CaseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageExtension = await _context.ImageExtensions.FindAsync(id);
            if (imageExtension != null)
            {
                _context.ImageExtensions.Remove(imageExtension);
                await _context.SaveChangesAsync();
            }

            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction("Index", "ImageExtensions");
        }

        private bool CaseTypeExists(int id)
        {
            return _context.ImageExtensions.Any(e => e.Id == id);
        }
    }
}
