using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtFusionStudio.Models;
using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.Physical;
using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures;
using ArtFusionStudio.Configuration;
using ArtFusionStudio.DataAccess.Repository.IRepository;

namespace ArtFusionStudio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [System.Web.Mvc.Authorize(Roles = AppConfiguration.AdminRole)]
    public class PhonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Phones
        public async Task<IActionResult> Index(string sortOrder)
        {
            DisplayLayoutController.AcceessAllTables(this, _context);
            DisplayLayoutController.AcceessAllTablesOS(this, _context);

            SortingController.SetProductSortingViewData(this, sortOrder);
            SortingController.SetPhoneSortingViewData(this, sortOrder);

            var sortedPhones = SortingController.GetSortedPhone(_context, sortOrder);

            return View(await sortedPhones.AsNoTracking().ToListAsync());

        }


        // GET: Admin/Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone
                .Include(p => p.Brand)
                .Include(p => p.Camera)
                .Include(p => p.Category)
                .Include(p => p.DisplayTechnology)
                .Include(p => p.OSNameAndVersion)
                    .ThenInclude(o =>o.OperatingSystemVersion)
                .Include(p => p.OSNameAndVersion)
                    .ThenInclude(o => o.OperatingSystem)
                .Include(p => p.Memory)
                .Include(p => p.StorageCapacity)
                .Include(p => p.USBType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);
            DisplayLayoutController.AcceessAllTablesOS(this, _context);

            return View(phone);
        }

        // GET: Admin/Phones/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Name");
            ViewData["CamerasId"] = new SelectList(_context.Set<Camera>(), "Id", "CameraCount");
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name");
            ViewData["DisplayTechnologyId"] = new SelectList(_context.Set<DisplayTechnology>(), "Id", "Name");
            ViewData["OSNameAndVersionId"] = new SelectList(_context.Set<OSNameAndVersion>(), "Id", "OSNamePlusVersion");
            ViewData["RAMMemorysId"] = new SelectList(_context.Set<Memory>(), "Id", "RAM");
            ViewData["StorageCapacityId"] = new SelectList(_context.Set<StorageCapacity>(), "Id", "CapacityGB");
            ViewData["USBTypeId"] = new SelectList(_context.Set<USB>(), "Id", "Type");
            DisplayLayoutController.AcceessAllTables(this, _context);
            DisplayLayoutController.AcceessAllTablesOS(this, _context);
            DisplayLayoutController.AccessAllHardwareTables(this, _context);

            return View();
        }

        // POST: Admin/Phones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,BrandId,,Name, ProductURL, Description, OldPrice, CurrentPrice, Quantity, USBTypeId,StorageCapacityId,RAMMemoryId,DisplayTechnologyId,CamerasId,OSNameAndVersionId,TotalVotes, Score,")] Phone phone)
        {
            DisplayLayoutController.AcceessAllTables(this, _context);
            DisplayLayoutController.AcceessAllTablesOS(this, _context);
            DisplayLayoutController.AccessAllHardwareTables(this, _context);

            if (ModelState.IsValid)
            {
                _context.Add(phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Name", phone.BrandId);
            ViewData["CamerasId"] = new SelectList(_context.Set<Camera>(), "Id", "Id", phone.CamerasId);
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", phone.CategoryId);
            ViewData["DisplayTechnologyId"] = new SelectList(_context.Set<DisplayTechnology>(), "Id", "Name", phone.DisplayTechnologyId);
            ViewData["OSNameAndVersionId"] = new SelectList(_context.Set<OSNameAndVersion>(), "Id", "Id", phone.OSNameAndVersion);
            ViewData["RAMMemoryId"] = new SelectList(_context.Set<Memory>(), "Id", "RAM", phone.RAMMemoryId);
            ViewData["StorageCapacityId"] = new SelectList(_context.Set<StorageCapacity>(), "Id", "Id", phone.StorageCapacity);
            ViewData["USBTypeId"] = new SelectList(_context.Set<USB>(), "Id", "Type", phone.USBTypeId);


            return View(phone);
        }

        // GET: Admin/Phones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Name", phone.BrandId);
            ViewData["CamerasId"] = new SelectList(_context.Set<Camera>(), "Id", "Id", phone.CamerasId);
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", phone.CategoryId);
            ViewData["DisplayTechnologyId"] = new SelectList(_context.Set<DisplayTechnology>(), "Id", "Name", phone.DisplayTechnologyId);
            ViewData["OSNameAndVersionId"] = new SelectList(_context.Set<OSNameAndVersion>(), "Id", "Id", phone.OSNameAndVersion);
            ViewData["RAMMemoryId"] = new SelectList(_context.Set<Memory>(), "Id", "RAM", phone.RAMMemoryId);
            ViewData["StorageCapacityId"] = new SelectList(_context.Set<StorageCapacity>(), "Id", "Id", phone.StorageCapacity);
            ViewData["USBTypeId"] = new SelectList(_context.Set<USB>(), "Id", "Type", phone.USBType);
            DisplayLayoutController.AcceessAllTables(this, _context);
            DisplayLayoutController.AcceessAllTablesOS(this, _context);
            DisplayLayoutController.AccessAllHardwareTables(this, _context);

            return View(phone);
        }

        // POST: Admin/Phones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,BrandId,,Name, ProductURL, Description, OldPrice, CurrentPrice, Quantity, USBTypeId,StorageCapacityId,RAMMemoryId,DisplayTechnologyId,CamerasId,OSNameAndVersionId,TotalVotes, Score,")] Phone phone)
        {
            if (id != phone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                DisplayLayoutController.AcceessAllTables(this, _context);
                DisplayLayoutController.AcceessAllTablesOS(this, _context);
                DisplayLayoutController.AccessAllHardwareTables(this, _context);

                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Name", phone.BrandId);
            ViewData["CamerasId"] = new SelectList(_context.Set<Camera>(), "Id", "Id", phone.CamerasId);
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", phone.CategoryId);
            ViewData["DisplayTechnologyId"] = new SelectList(_context.Set<DisplayTechnology>(), "Id", "Name", phone.DisplayTechnologyId);
            ViewData["OSNameAndVersionId"] = new SelectList(_context.Set<OSNameAndVersion>(), "Id", "Id", phone.OSNameAndVersion.OSNamePlusVersion);
            ViewData["RAMMemorysId"] = new SelectList(_context.Set<Memory>(), "Id", "RAM", phone.Memory.RAM);
            ViewData["StorageCapacityId"] = new SelectList(_context.Set<StorageCapacity>(), "Id", "Id", phone.StorageCapacity.CapacityGB);
            ViewData["USBTypeId"] = new SelectList(_context.Set<USB>(), "Id", "Type", phone.USBTypeId);
            DisplayLayoutController.AcceessAllTables(this, _context);
            DisplayLayoutController.AccessAllHardwareTables(this, _context);

            return View(phone);
        }

        // GET: Admin/Phones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone
                .Include(p => p.Brand)
                .Include(p => p.Camera)
                .Include(p => p.Category)
                .Include(p => p.DisplayTechnology)
                .Include(p => p.OSNameAndVersion)
                .Include(p => p.Memory)
                .Include(p => p.StorageCapacity)
                .Include(p => p.USBType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }
            DisplayLayoutController.AcceessAllTables(this, _context);

            return View(phone);
        }

        // POST: Admin/Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phone = await _context.Phone.FindAsync(id);
            if (phone != null)
            {
                _context.Phone.Remove(phone);
            }

            await _context.SaveChangesAsync();
            DisplayLayoutController.AcceessAllTables(this, _context);
            DisplayLayoutController.AcceessAllTablesOS(this, _context);

            return RedirectToAction(nameof(Index));
        }

        private bool PhoneExists(int id)
        {
            return _context.Phone.Any(e => e.Id == id);
        }
    }
}
