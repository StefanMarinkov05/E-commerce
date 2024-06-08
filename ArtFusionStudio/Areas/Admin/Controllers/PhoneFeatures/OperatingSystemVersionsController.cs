using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures;
using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Configuration;

namespace ArtFusionStudio.Areas.Admin.Controllers.PhoneFeatures
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class OperatingSystemVersionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OperatingSystemVersionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/OperatingSystemVersions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/OperatingSystemVersions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OSVersion")] OperatingSystemVersion operatingSystemVersion)
        {
            if(_context.OperatingSystemVersion.FirstOrDefault(s => s.OSVersion == operatingSystemVersion.OSVersion) != null)
            {
                ModelState.AddModelError("OSVersion", "Вече има същата версия");
            }

            if (ModelState.IsValid)
            {
                _context.Add(operatingSystemVersion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "OSNameAndVersions");
            }
            return View(operatingSystemVersion);
        }

        // GET: Admin/OperatingSystemVersions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operatingSystemVersion = await _context.OperatingSystemVersion.FindAsync(id);
            if (operatingSystemVersion == null)
            {
                return NotFound();
            }
            return View(operatingSystemVersion);
        }

        // POST: Admin/OperatingSystemVersions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OSVersion")] OperatingSystemVersion operatingSystemVersion)
        {
            if (id != operatingSystemVersion.Id)
            {
                return NotFound();
            }

            if (_context.OperatingSystemVersion.FirstOrDefault(s => s.OSVersion == operatingSystemVersion.OSVersion) != null)
            {
                ModelState.AddModelError("OSVersion", "Вече има същата версия");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operatingSystemVersion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperatingSystemVersionExists(operatingSystemVersion.Id))
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
            return View(operatingSystemVersion);
        }

        // GET: Admin/OperatingSystemVersions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operatingSystemVersion = await _context.OperatingSystemVersion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operatingSystemVersion == null)
            {
                return NotFound();
            }

            return View(operatingSystemVersion);
        }

        // POST: Admin/OperatingSystemVersions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operatingSystemVersion = await _context.OperatingSystemVersion.FindAsync(id);
            if (operatingSystemVersion != null)
            {
                _context.OperatingSystemVersion.Remove(operatingSystemVersion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "OSNameAndVersions");
        }

        private bool OperatingSystemVersionExists(int id)
        {
            return _context.OperatingSystemVersion.Any(e => e.Id == id);
        }
    }
}
