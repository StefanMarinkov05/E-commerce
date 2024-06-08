using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Areas.Admin.Controllers;
using Microsoft.Data.SqlClient;
using ArtFusionStudio.Models;

namespace ArtFusionStudio.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customer/Products
        public async Task<IActionResult> Index(string sortOrder, int? brandId)
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            SortingController.SetProductSortingViewData(this, sortOrder);

            var sortedProducts = SortingController.GetSortedProduct(_context, sortOrder);

            if (brandId.HasValue)
            {
                sortedProducts = sortedProducts.Where(p => p.BrandId == brandId);
                ViewData["BrandId"] = brandId == null ? null : brandId;
            }

            return View(await sortedProducts.AsNoTracking().ToListAsync());
        }

        // GET: Customer/Productss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);
            DisplayLayoutController.AccessAllHardwareTables(this, _context);
            DisplayLayoutController.AcceessAllTablesOS(this, _context);
            DisplayLayoutController.AccessAllAestheticTables(this, _context);
            DisplayLayoutController.AccessAllProductTables(this, _context);

            return View(products);
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
