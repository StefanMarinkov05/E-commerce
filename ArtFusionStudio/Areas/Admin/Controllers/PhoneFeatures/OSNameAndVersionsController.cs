using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures;
using OSSnippet = ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.OperatingSystem;
using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Configuration;
using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.Physical;
using ArtFusionStudio.Models;
using ArtFusionStudio.Utility;

namespace ArtFusionStudio.Areas.Admin.Controllers.PhoneFeatures
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class OSNameAndVersionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OSNameAndVersionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/OSNameAndVersions
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var artFusionStudioContext = _context.OSNameAndVersion.Include(o => o.OperatingSystem).Include(o => o.OperatingSystemVersion);
            DisplayLayoutController.AcceessAllTables(this, _context);
            DisplayLayoutController.AcceessAllTablesOS(this, _context)
                ;
            var oss = from o in _context.OSNameAndVersion
                      .Include(o => o.OperatingSystem)
                      .Include(o => o.OperatingSystemVersion)
                      select o;

            return View(await PaginatedList<OSNameAndVersion>.CreateAsync(oss.AsNoTracking(), pageNumber ?? 1, StaticDetails.pageSize));
            //return View(await artFusionStudioContext.ToListAsync());
        }


        // GET: Admin/OSNameAndVersions/Create
        public IActionResult Create()
        {
            ViewData["OSNameId"] = new SelectList(_context.Set<OSSnippet>(), "Id", "OSName");
            ViewData["OSVersionId"] = new SelectList(_context.OperatingSystemVersion, "Id", "Id");
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View();
        }

        // POST: Admin/OSNameAndVersions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OSNameId,OSVersionId")] OSNameAndVersion oSNameAndVersion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oSNameAndVersion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OSNameId"] = new SelectList(_context.Set<OSSnippet>(), "Id", "OSName", oSNameAndVersion.OSNameId);
            ViewData["OSVersionId"] = new SelectList(_context.OperatingSystemVersion, "Id", "Id", oSNameAndVersion.OSVersionId);
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(oSNameAndVersion);
        }

        // GET: Admin/OSNameAndVersions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSNameAndVersion = await _context.OSNameAndVersion.FindAsync(id);
            if (oSNameAndVersion == null)
            {
                return NotFound();
            }
            ViewData["OSNameId"] = new SelectList(_context.Set<OSSnippet>(), "Id", "OSName", oSNameAndVersion.OSNameId);
            ViewData["OSVersionId"] = new SelectList(_context.OperatingSystemVersion, "Id", "Id", oSNameAndVersion.OSVersionId);
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(oSNameAndVersion);
        }

        // POST: Admin/OSNameAndVersions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OSNameId,OSVersionId")] OSNameAndVersion oSNameAndVersion)
        {
            if (id != oSNameAndVersion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oSNameAndVersion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OSNameAndVersionExists(oSNameAndVersion.Id))
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
            ViewData["OSNameId"] = new SelectList(_context.Set<OSSnippet>(), "Id", "OSName", oSNameAndVersion.OSNameId);
            ViewData["OSVersionId"] = new SelectList(_context.OperatingSystemVersion, "Id", "Id", oSNameAndVersion.OSVersionId);
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(oSNameAndVersion);
        }

        // GET: Admin/OSNameAndVersions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSNameAndVersion = await _context.OSNameAndVersion
                .Include(o => o.OperatingSystem)
                .Include(o => o.OperatingSystemVersion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oSNameAndVersion == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(oSNameAndVersion);
        }

        // POST: Admin/OSNameAndVersions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oSNameAndVersion = await _context.OSNameAndVersion.FindAsync(id);
            if (oSNameAndVersion != null)
            {
                _context.OSNameAndVersion.Remove(oSNameAndVersion);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction(nameof(Index));
        }

        private bool OSNameAndVersionExists(int id)
        {
            return _context.OSNameAndVersion.Any(e => e.Id == id);
        }
    }
}
