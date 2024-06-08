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
    public class ImageExtensionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImageExtensionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CaseTypes
        public async Task<IActionResult> Index()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(await _context.ImageExtensions.ToListAsync());
        }


        // GET: Admin/CaseTypes/Create
        public IActionResult Create()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View();
        }

        // POST: Admin/CaseTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Extension")] ImageExtension imageExtension)
        {
            if (_context.ImageExtensions.FirstOrDefault(ie => ie.Extension.ToLower().Replace(" ", "") == imageExtension.Extension.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Extension", "Вече има същото разширение");
            }

            if (ModelState.IsValid)
            {
                _context.Add(imageExtension);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ApplicationUsers");
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(imageExtension);
        }

        // GET: Admin/CaseTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageExtension = await _context.ImageExtensions.FindAsync(id);
            if (imageExtension == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(imageExtension);
        }

        // POST: Admin/CaseTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Extension")] ImageExtension imageExtension)
        {
            if (id != imageExtension.Id)
            {
                return NotFound();
            }

            if (_context.ImageExtensions.FirstOrDefault(ie => ie.Extension.ToLower().Replace(" ", "") == imageExtension.Extension.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Name", "Вече има същото разширение");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageExtension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseTypeExists(imageExtension.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "ApplicationUsers");
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(imageExtension);
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

            return RedirectToAction("Index", "ApplicationUsers");
        }

        private bool CaseTypeExists(int id)
        {
            return _context.ImageExtensions.Any(e => e.Id == id);
        }
    }
}
