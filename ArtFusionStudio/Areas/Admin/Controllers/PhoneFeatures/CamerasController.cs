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
    public class CamerasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CamerasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Cameras/Create
        public IActionResult Create()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View();
        }

        // POST: Admin/Cameras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CameraCount")] Camera camera)
        {
            if (_context.Camera.FirstOrDefault(c => c.CameraCount == camera.CameraCount) != null)
            {
                ModelState.AddModelError("CameraCount", "Вече има този брой камери");
            }

            if (ModelState.IsValid)
            {
                _context.Add(camera);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "DisplayTechnologies");
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(camera);
        }

        // GET: Admin/Cameras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camera = await _context.Camera.FindAsync(id);
            if (camera == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(camera);
        }

        // POST: Admin/Cameras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CameraCount")] Camera camera)
        {
            if (id != camera.Id)
            {
                return NotFound();
            }

            if (_context.Camera.FirstOrDefault(c => c.CameraCount == camera.CameraCount) != null)
            {
                ModelState.AddModelError("CameraCount", "Вече има този брой камери");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CameraExists(camera.Id))
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

            return View(camera);
        }

        // GET: Admin/Cameras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camera = await _context.Camera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camera == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(camera);
        }

        // POST: Admin/Cameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camera = await _context.Camera.FindAsync(id);
            if (camera != null)
            {
                _context.Camera.Remove(camera);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction("Index", "DisplayTechnologies");
        }

        private bool CameraExists(int id)
        {
            return _context.Camera.Any(e => e.Id == id);
        }
    }
}
