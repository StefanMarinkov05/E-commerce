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

namespace ArtFusionStudio.Areas.Admin.Controllers.PhoneFeatures
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class DisplayTechnologiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisplayTechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DisplayTechnologies
        public async Task<IActionResult> Index()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);
            DisplayLayoutController.AccessAllHardwareTables(this, _context);

            return View(await _context.DisplayTechnology.ToListAsync());
        }


        // GET: Admin/DisplayTechnologies/Create
        public IActionResult Create()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View();
        }

        // POST: Admin/DisplayTechnologies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DisplayTechnology displayTechnology)
        {
            if (_context.DisplayTechnology.FirstOrDefault(d => d.Name.ToLower().Replace(" ", "") == displayTechnology.Name.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Name", "Вече има същата технология");
            }

            if (ModelState.IsValid)
            {
                _context.Add(displayTechnology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(displayTechnology);
        }

        // GET: Admin/DisplayTechnologies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var displayTechnology = await _context.DisplayTechnology.FindAsync(id);
            if (displayTechnology == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(displayTechnology);
        }

        // POST: Admin/DisplayTechnologies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DisplayTechnology displayTechnology)
        {
            if (id != displayTechnology.Id)
            {
                return NotFound();
            }

            if (_context.DisplayTechnology.FirstOrDefault(d => d.Name.ToLower().Replace(" ", "") == displayTechnology.Name.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Name", "Вече има същата технология");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(displayTechnology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisplayTechnologyExists(displayTechnology.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(displayTechnology);
        }

        // GET: Admin/DisplayTechnologies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var displayTechnology = await _context.DisplayTechnology
                .FirstOrDefaultAsync(m => m.Id == id);
            if (displayTechnology == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(displayTechnology);
        }

        // POST: Admin/DisplayTechnologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var displayTechnology = await _context.DisplayTechnology.FindAsync(id);
            if (displayTechnology != null)
            {
                _context.DisplayTechnology.Remove(displayTechnology);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction(nameof(Index));
        }

        private bool DisplayTechnologyExists(int id)
        {
            return _context.DisplayTechnology.Any(e => e.Id == id);
        }
    }
}
