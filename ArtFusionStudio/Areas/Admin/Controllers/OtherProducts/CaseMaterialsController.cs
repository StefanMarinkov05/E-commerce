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
    public class CaseMaterialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaseMaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Admin/CaseMaterials/Create
        public IActionResult Create()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View();
        }

        // POST: Admin/CaseMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CaseMaterial caseMaterial)
        {
            if (_context.CaseMaterial.FirstOrDefault(c => c.Name.ToLower().Replace(" ", "") == caseMaterial.Name.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Name", "Вече има същия материал");
            }

            if (ModelState.IsValid)
            {
                _context.Add(caseMaterial);
                await _context.SaveChangesAsync();

                DisplayLayoutController.AcceessAllTables(this, _context);

                return RedirectToAction("Index","CaseTypes");
            }
            return View(caseMaterial);
        }

        // GET: Admin/CaseMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseMaterial = await _context.CaseMaterial.FindAsync(id);
            if (caseMaterial == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(caseMaterial);
        }

        // POST: Admin/CaseMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CaseMaterial caseMaterial)
        {
            if (id != caseMaterial.Id)
            {
                return NotFound();
            }

            if (_context.CaseMaterial.FirstOrDefault(c => c.Name.ToLower().Replace(" ","") == caseMaterial.Name.ToLower().Replace(" ", "")) != null)
            {
                ModelState.AddModelError("Name", "Вече има същия материал");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseMaterialExists(caseMaterial.Id))
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

            return View(caseMaterial);
        }

        // GET: Admin/CaseMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var caseMaterial = await _context.CaseMaterial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseMaterial == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(caseMaterial);
        }

        // POST: Admin/CaseMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caseMaterial = await _context.CaseMaterial.FindAsync(id);
            if (caseMaterial != null)
            {
                _context.CaseMaterial.Remove(caseMaterial);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction("Index", "CaseTypes");
        }

        private bool CaseMaterialExists(int id)
        {
            return _context.CaseMaterial.Any(e => e.Id == id);
        }
    }
}
