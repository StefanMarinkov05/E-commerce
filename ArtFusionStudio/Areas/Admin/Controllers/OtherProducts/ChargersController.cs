using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtFusionStudio.Models.ProductFeatures.PhoneAccessories;
using ArtFusionStudio.Models;
using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Configuration;
using Microsoft.Data.SqlClient;

namespace ArtFusionStudio.Areas.Admin.Controllers.OtherProducts
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class ChargersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChargersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Chargers
        public async Task<IActionResult> Index(string sortOrder)
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            SortingController.SetProductSortingViewData(this, sortOrder);
            SortingController.SetChargerSortingViewData(this, sortOrder);

            var sortedChargers = SortingController.GetSortedChargers(_context, sortOrder);

            return View(await sortedChargers.AsNoTracking().ToListAsync());
        }

        // GET: Admin/Chargers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charger = await _context.Charger
                .Include(c => c.Brand)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (charger == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(charger);
        }

        // GET: Admin/Chargers/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name");
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View();
        }

        // POST: Admin/Chargers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OutputVoltage,OutputCurrent,FastChargingSupported,Id,Name,Description,ProductURL,OldPrice,CurrentPrice,CategoryId,BrandId,TotalVotes,Score")] Charger charger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(charger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Name", charger.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", charger.CategoryId);
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(charger);
        }

        // GET: Admin/Chargers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charger = await _context.Charger.FindAsync(id);
            if (charger == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Name", charger.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", charger.CategoryId);
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(charger);
        }

        // POST: Admin/Chargers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OutputVoltage,OutputCurrent,FastChargingSupported,Id,Name,Description,ProductURL,OldPrice,CurrentPrice,CategoryId,BrandId,TotalVotes,Score")] Charger charger)
        {
            if (id != charger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(charger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChargerExists(charger.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                DisplayLayoutController.AcceessAllTables(this, _context);

                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Name", charger.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", charger.CategoryId);
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(charger);
        }

        // GET: Admin/Chargers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charger = await _context.Charger
                .Include(c => c.Brand)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (charger == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(charger);
        }

        // POST: Admin/Chargers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var charger = await _context.Charger.FindAsync(id);
            if (charger != null)
            {
                _context.Charger.Remove(charger);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction(nameof(Index));
        }

        private bool ChargerExists(int id)
        {
            return _context.Charger.Any(e => e.Id == id);
        }
    }
}
