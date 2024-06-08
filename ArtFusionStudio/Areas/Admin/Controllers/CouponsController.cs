using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtFusionStudio.Models.ProductFeatures;
using ArtFusionStudio.Models;
using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Utility;
using ArtFusionStudio.Configuration;

namespace ArtFusionStudio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class CouponsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CouponsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);
            var artFusionStudioContext = _context.Coupon.Include(c => c.Product);
            return View(await artFusionStudioContext.ToListAsync());
        }

        // GET: Admin/Coupons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupon
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(coupon);
        }


        // GET: Admin/Coupons/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Name");
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View();
        }

        // POST: Admin/Coupons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DiscountCode,DiscountPercentage,ProductId,StartDate,EndDate")] Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                // Additional custom validation for EndDate
                if (coupon.StartDate > coupon.EndDate)
                {
                    ModelState.AddModelError("EndDate", ErrorMessages.INVALID_END_DATE);
                    ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Name", coupon.ProductId);
                    return View(coupon);
                }

                _context.Add(coupon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Name", coupon.ProductId);
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(coupon);
        }

        // GET: Admin/Coupons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupon.FindAsync(id);
            if (coupon == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Name", coupon.ProductId);
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(coupon);
        }

        // POST: Admin/Coupons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DiscountCode,DiscountPercentage,ProductId,StartDate,EndDate")] Coupon coupon)
        {
            if (id != coupon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Additional custom validation for EndDate
                if (coupon.StartDate > coupon.EndDate)
                {
                    ModelState.AddModelError("EndDate", ErrorMessages.INVALID_END_DATE);
                    ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Name", coupon.ProductId);
                    return View(coupon);
                }

                try
                {
                    _context.Update(coupon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouponExists(coupon.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Name", coupon.ProductId);
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(coupon);
        }

        // GET: Admin/Coupons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupon
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(coupon);
        }

        // POST: Admin/Coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coupon = await _context.Coupon.FindAsync(id);
            if (coupon != null)
            {
                _context.Coupon.Remove(coupon);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);

            return RedirectToAction(nameof(Index));
        }

        private bool CouponExists(int id)
        {
            return _context.Coupon.Any(e => e.Id == id);
        }
    }
}
