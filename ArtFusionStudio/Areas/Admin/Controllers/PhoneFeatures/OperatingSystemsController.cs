using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OSSnippet = ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.OperatingSystem;
using ArtFusionStudio.DataAccess.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ArtFusionStudio.Configuration;
using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.Physical;

namespace ArtFusionStudio.Areas.Admin.Controllers.PhoneFeatures
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class OperatingSystemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OperatingSystemsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Admin/OperatingSystems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/OperatingSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OSName")] OSSnippet operatingSystem)
        {
            if (_context.OperatingSystems.FirstOrDefault(d => d.OSName.ToLower().Replace(" ", "") == operatingSystem.OSName.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("OSName", "Вече има същата ОС");
            }

            if (ModelState.IsValid)
            {
                _context.Add(operatingSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "OSNameAndVersions");
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(operatingSystem);
        }

        // GET: Admin/OperatingSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operatingSystem = await _context.OperatingSystems.FindAsync(id);
            if (operatingSystem == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(operatingSystem);
        }

        // POST: Admin/OperatingSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OSName")] OSSnippet operatingSystem)
        {
            if (id != operatingSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operatingSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperatingSystemExists(operatingSystem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "OSNameAndVersions");
            }
            return View(operatingSystem);
        }

        // GET: Admin/OperatingSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operatingSystem = await _context.OperatingSystems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operatingSystem == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(operatingSystem);
        }

        // POST: Admin/OperatingSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operatingSystem = await _context.OperatingSystems.FindAsync(id);
            if (operatingSystem != null)
            {
                _context.OperatingSystems.Remove(operatingSystem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "OSNameAndVersions");
        }

        private bool OperatingSystemExists(int id)
        {
            return _context.OperatingSystems.Any(e => e.Id == id);
        }
    }
}
