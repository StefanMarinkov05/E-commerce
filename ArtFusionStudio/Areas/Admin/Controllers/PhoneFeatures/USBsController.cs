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
using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures;

namespace ArtFusionStudio.Areas.Admin.Controllers.PhoneFeatures
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class USBsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public USBsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/USBs/Create
        public IActionResult Create()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View();
        }

        // POST: Admin/USBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] USB uSB)
        {
            if (_context.USB.FirstOrDefault(u => u.Type.ToLower().Replace(" ", "") == uSB.Type.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Type", "Вече има този USB порт");
            }

            if (ModelState.IsValid)
            {
                _context.Add(uSB);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "DisplayTechnologies");
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(uSB);
        }

        // GET: Admin/USBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uSB = await _context.USB.FindAsync(id);
            if (uSB == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(uSB);
        }

        // POST: Admin/USBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] USB uSB)
        {
            if (id != uSB.Id)
            {
                return NotFound();
            }

            if (_context.USB.FirstOrDefault(u => u.Type.ToLower().Replace(" ", "") == uSB.Type.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Type", "Вече има този USB порт");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uSB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!USBExists(uSB.Id))
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

            return View(uSB);
        }

        // GET: Admin/USBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uSB = await _context.USB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uSB == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(uSB);
        }

        // POST: Admin/USBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uSB = await _context.USB.FindAsync(id);
            if (uSB != null)
            {
                _context.USB.Remove(uSB);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction("Index", "DisplayTechnologies");
        }

        private bool USBExists(int id)
        {
            return _context.USB.Any(e => e.Id == id);
        }
    }
}
