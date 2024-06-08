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

namespace ArtFusionStudio.Areas.Admin.Controllers.OtherProducts
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class CasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Cases
        public async Task<IActionResult> Index(string sortOrder)
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            SortingController.SetProductSortingViewData(this, sortOrder);
            SortingController.SetCaseSortingViewData(this, sortOrder);

            var sortedCases = SortingController.GetSortedCases(_context, sortOrder);

            return View(await sortedCases.AsNoTracking().ToListAsync());
        }

        // GET: Admin/Cases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case
                .Include(c => c.Brand)
                .Include(c => c.CaseMaterial)
                .Include(c => c.CaseType)
                .Include(c => c.Category)
                .Include(c => c.ProtectionLevel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if  (@case == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(@case);
        }

        // GET: Admin/Cases/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Name");
            ViewData["CaseMaterialsId"] = new SelectList(_context.Set<CaseMaterial>(), "Id", "Name");
            ViewData["CaseTypesId"] = new SelectList(_context.Set<CaseType>(), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name");
            ViewData["ProtectionLevelId"] = new SelectList(_context.Set<ProtectionLevel>(), "Id", "Protection");
            DisplayLayoutController.AcceessAllTables(this, _context);
            DisplayLayoutController.AccessAllAestheticTables(this, _context);

            return View();
        }

        // POST: Admin/Cases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProtectionLevelId,CaseMaterialId,CaseTypeId,Id,Name,Description,ProductURL,OldPrice,CurrentPrice,CategoryId,BrandId,TotalVotes,Score")] Case @case)
        {
            DisplayLayoutController.AccessAllAestheticTables(this, _context);
            DisplayLayoutController.AcceessAllTables(this, _context);

            if (ModelState.IsValid)
            {
                _context.Add(@case);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Name", @case.BrandId);
            ViewData["CaseMaterialsId"] = new SelectList(_context.Set<CaseMaterial>(), "Id", "Name", @case.CaseMaterialId);
            ViewData["CaseTypesId"] = new SelectList(_context.Set<CaseType>(), "Id", "Name", @case.CaseTypeId);
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", @case.CategoryId);
            ViewData["ProtectionLevelId"] = new SelectList(_context.Set<ProtectionLevel>(), "Id", "Protection", @case.ProtectionLevelId);

            return View(@case);
        }

        // GET: Admin/Cases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case.FindAsync(id);
            if  (@case == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Name", @case.BrandId);
            ViewData["CaseMaterialsId"] = new SelectList(_context.Set<CaseMaterial>(), "Id", "Name", @case.CaseMaterialId);
            ViewData["CaseTypesId"] = new SelectList(_context.Set<CaseType>(), "Id", "Name", @case.CaseTypeId);
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", @case.CategoryId);
            ViewData["ProtectionLevelId"] = new SelectList(_context.Set<ProtectionLevel>(), "Id", "Protection", @case.ProtectionLevelId);
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(@case);
        }

        // POST: Admin/Cases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProtectionLevelId,CaseMaterialId,CaseTypeId,Id,Name,Description,ProductURL,OldPrice,CurrentPrice,CategoryId,BrandId,TotalVotes,Score")] Case @case)
        {
            if (id != @case.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseExists(@case.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Name", @case.BrandId);
            ViewData["CaseMaterialsId"] = new SelectList(_context.Set<CaseMaterial>(), "Id", "Name", @case.CaseMaterialId);
            ViewData["CaseTypesId"] = new SelectList(_context.Set<CaseType>(), "Id", "Name", @case.CaseTypeId);
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", @case.CategoryId);
            ViewData["ProtectionLevelId"] = new SelectList(_context.Set<ProtectionLevel>(), "Id", "Protection", @case.ProtectionLevelId);
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(@case);
        }

        // GET: Admin/Cases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case
                .Include(c => c.Brand)
                .Include(c => c.CaseMaterial)
                .Include(c => c.CaseType)
                .Include(c => c.Category)
                .Include(c => c.ProtectionLevel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if  (@case == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(@case);
        }

        // POST: Admin/Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @case = await _context.Case.FindAsync(id);
            if  (@case != null)
            {
                _context.Case.Remove(@case);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction(nameof(Index));
        }

        private bool CaseExists(int id)
        {
            return _context.Case.Any(e => e.Id == id);
        }
    }
}
