using ArtFusionStudio.Areas.Admin.Controllers;
using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Models;
using ArtFusionStudio.Models.ProductFeatures.PhoneAccessories;
using ArtFusionStudio.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ArtFusionStudio.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);
            return View(_context.Phone.ToList());
        }
    }
}
