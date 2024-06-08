using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Models;
using ArtFusionStudio.Utility;
using ArtFusionStudio.Configuration;
using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures;

namespace ArtFusionStudio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class BrandController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrandController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Brand

        public async Task<IActionResult> Index(string sortOrder,
            int? pageNumber)
        {
            DisplayLayoutController.AcceessAllTables(this, _context);
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IdSortParm"] = sortOrder == "Id" ? "id_desc" : "Id";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";

            var brands = from b in _context.Brands
                         select b;

            switch (sortOrder)
            {
                case "Id":
                    brands = brands.OrderByDescending(b => b.Id);
                    break;
                case "Name":
                    brands = brands.OrderBy(b => b.Name);
                    break;
                case "name_desc":
                    brands = brands.OrderByDescending(b => b.Name);
                    break;
                default:
                    brands = brands.OrderBy(b => b.Id);
                    break;
            }
            return View(await PaginatedList<Brand>.CreateAsync(brands.AsNoTracking(), pageNumber ?? 1, StaticDetails.pageSize));
        }

        // GET: Brand/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            DisplayLayoutController.AcceessAllTables(this, _context);

            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Brand/Create
        public IActionResult Create()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View();
        }

        // POST: Brand/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PathD")] Brand brand)
        {
            if (_context.Brands.FirstOrDefault(b => b.Name.ToLower().Replace(" ", "") == brand.Name.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Name", "Вече има такава марка");
            }

            if (ModelState.IsValid)
            {
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            DisplayLayoutController.AcceessAllTables(this, _context);
            return View(brand);
        }

        // GET: Brand/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(brand);
        }

        // POST: Brand/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PathD")] Brand brand)
        {

            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.Id))
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

            return View(brand);
        }

        // GET: Brand/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(brand);
        }

        // POST: Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.Id == id);
        }
    }
}
