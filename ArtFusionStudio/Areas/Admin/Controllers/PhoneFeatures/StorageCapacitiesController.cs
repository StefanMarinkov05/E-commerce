using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.Physical;
using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Configuration;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace ArtFusionStudio.Areas.Admin.Controllers.PhoneFeatures
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class StorageCapacitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StorageCapacitiesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Admin/StorageCapacities/Create
        public IActionResult Create()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View();
        }

        // POST: Admin/StorageCapacities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CapacityGB")] StorageCapacity storageCapacity)
        {
            if (_context.StorageCapacity.FirstOrDefault(s => s.CapacityGB == storageCapacity.CapacityGB) != null)
            {
                ModelState.AddModelError("CapacityGB", "Вече има толкова памет");
            }

            if (ModelState.IsValid)
            {
                _context.Add(storageCapacity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "DisplayTechnologies");
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(storageCapacity);
        }

        // GET: Admin/StorageCapacities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageCapacity = await _context.StorageCapacity.FindAsync(id);
            if (storageCapacity == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(storageCapacity);
        }

        // POST: Admin/StorageCapacities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CapacityGB")] StorageCapacity storageCapacity)
        {
            if (id != storageCapacity.Id)
            {
                return NotFound();
            }

            if (_context.StorageCapacity.FirstOrDefault(s => s.CapacityGB == storageCapacity.CapacityGB) != null)
            {
                ModelState.AddModelError("CapacityGB", "Вече има толкова памет");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storageCapacity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorageCapacityExists(storageCapacity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "DisplayTechnologies");
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(storageCapacity);
        }

        // GET: Admin/StorageCapacities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageCapacity = await _context.StorageCapacity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storageCapacity == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(storageCapacity);
        }

        // POST: Admin/StorageCapacities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storageCapacity = await _context.StorageCapacity.FindAsync(id);
            if (storageCapacity != null)
            {
                _context.StorageCapacity.Remove(storageCapacity);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction("Index", "DisplayTechnologies");
        }

        private bool StorageCapacityExists(int id)
        {
            return _context.StorageCapacity.Any(e => e.Id == id);
        }
    }
}
