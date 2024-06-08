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

namespace ArtFusionStudio.Areas.Admin.Controllers.OtherProducts
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class ProtectionLevelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProtectionLevelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Admin/ProtectionLevels/Create
        public IActionResult Create()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View();
        }

        // POST: Admin/ProtectionLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Protection")] ProtectionLevel protectionLevel)
        {
            if (_context.ProtectionLevel.FirstOrDefault(p => p.Protection.ToLower().Replace(" ", "") == protectionLevel.Protection.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Protection", "Вече има същата защита");
            }

            if (ModelState.IsValid)
            {
                _context.Add(protectionLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "CaseTypes");
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(protectionLevel);
        }

        // GET: Admin/ProtectionLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protectionLevel = await _context.ProtectionLevel.FindAsync(id);
            if (protectionLevel == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(protectionLevel);
        }

        // POST: Admin/ProtectionLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Protection")] ProtectionLevel protectionLevel)
        {
            if (id != protectionLevel.Id)
            {
                return NotFound();
            }

            if (_context.ProtectionLevel.FirstOrDefault(p => p.Protection.ToLower().Replace(" ", "") == protectionLevel.Protection.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Protection", "Вече има същата защита");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(protectionLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProtectionLevelExists(protectionLevel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "CaseTypes");
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(protectionLevel);
        }

        // GET: Admin/ProtectionLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protectionLevel = await _context.ProtectionLevel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (protectionLevel == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(protectionLevel);
        }

        // POST: Admin/ProtectionLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protectionLevel = await _context.ProtectionLevel.FindAsync(id);
            if (protectionLevel != null)
            {
                _context.ProtectionLevel.Remove(protectionLevel);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction("Index", "CaseTypes");
        }

        private bool ProtectionLevelExists(int id)
        {
            return _context.ProtectionLevel.Any(e => e.Id == id);
        }
    }
}
