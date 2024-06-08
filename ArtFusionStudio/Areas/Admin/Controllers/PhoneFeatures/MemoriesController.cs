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
    public class MemoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemoriesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Admin/Memories/Create
        public IActionResult Create()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View();
        }

        // POST: Admin/Memories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RAM")] Memory memory)
        {
            if (_context.Memory.FirstOrDefault(c => c.RAM == memory.RAM) != null)
            {
                ModelState.AddModelError("RAM", "Вече има толкова RAM");
            }

            if (ModelState.IsValid)
            {
                _context.Add(memory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "DisplayTechnologies");
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(memory);
        }

        // GET: Admin/Memories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memory = await _context.Memory.FindAsync(id);
            if (memory == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(memory);
        }

        // POST: Admin/Memories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RAM")] Memory memory)
        {
            if (id != memory.Id)
            {
                return NotFound();
            }

            if (_context.Memory.FirstOrDefault(c => c.RAM == memory.RAM) != null)
            {
                ModelState.AddModelError("RAM", "Вече има толкова RAM");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemoryExists(memory.Id))
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

            return View(memory);
        }

        // GET: Admin/Memories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memory = await _context.Memory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memory == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(memory);
        }

        // POST: Admin/Memories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memory = await _context.Memory.FindAsync(id);
            if (memory != null)
            {
                _context.Memory.Remove(memory);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction("Index", "DisplayTechnologies");
        }

        private bool MemoryExists(int id)
        {
            return _context.Memory.Any(e => e.Id == id);
        }
    }
}
