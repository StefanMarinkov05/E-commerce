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
    public class CaseTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaseTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CaseTypes
        public async Task<IActionResult> Index()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);
            DisplayLayoutController.AccessAllAestheticTables(this, _context);

            return View(await _context.CaseType.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Name")] CaseType caseType)
        {
            if (_context.CaseType.FirstOrDefault(c => c.Name.ToLower().Replace(" ", "") == caseType.Name.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Name", "Вече има същия тип");
            }

            if (ModelState.IsValid)
            {
                _context.Add(caseType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(caseType);
        }

        // GET: Admin/CaseTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseType = await _context.CaseType.FindAsync(id);
            if (caseType == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(caseType);
        }

        // POST: Admin/CaseTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CaseType caseType)
        {
            if (id != caseType.Id)
            {
                return NotFound();
            }

            if (_context.CaseType.FirstOrDefault(c => c.Name.ToLower().Replace(" ", "") == caseType.Name.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Name", "Вече има същия тип");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseTypeExists(caseType.Id))
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

            return View(caseType);
        }

        // GET: Admin/CaseTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseType = await _context.CaseType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseType == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(caseType);
        }

        // POST: Admin/CaseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caseType = await _context.CaseType.FindAsync(id);
            if (caseType != null)
            {
                _context.CaseType.Remove(caseType);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction(nameof(Index));
        }

        private bool CaseTypeExists(int id)
        {
            return _context.CaseType.Any(e => e.Id == id);
        }
    }
}
