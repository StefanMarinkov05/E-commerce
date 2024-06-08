using ArtFusionStudio.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using ArtFusionStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtFusionStudio.Areas.Admin.Controllers
{
    public class DisplayLayoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisplayLayoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public static void AcceessAllTables(Controller controller, ApplicationDbContext context)
        {
            controller.ViewData["Category"] = context.Categories.ToList();
            controller.ViewData["Brand"] = context.Brands.ToList();
            controller.ViewData["Product"] = context.Products.ToList();

            if (controller.User != null)
            {
                string? userId = controller.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (userId != null)
                {
                    var shoppingCart = context.ShoppingCarts.FirstOrDefault(u => u.UserId == userId);
                    controller.ViewData["ShoppingCart"] = shoppingCart;
                    if (shoppingCart != null)
                    {
                        controller.ViewData["ShoppingCartItem"] = context.ShoppingCartItems.Where(sci => sci.CartId == shoppingCart.Id).ToList();
                    }
                }
            }
        }

        public static void AcceessAllTablesOS(Controller controller, ApplicationDbContext context)
        {
            controller.ViewData["OSName"] = context.OperatingSystems.ToList();
            controller.ViewData["OSVersions"] = context.OperatingSystemVersion.ToList();
            controller.ViewData["OSNameAndVersion"] = context.OSNameAndVersion.ToList();
        }

        public static void AccessAllAestheticTables(Controller controller, ApplicationDbContext context)
        {
            controller.ViewData["CaseMaterials"] = context.CaseMaterial.ToList();
            controller.ViewData["CaseTypes"] = context.CaseType.ToList();
            controller.ViewData["ProtectionLevels"] = context.ProtectionLevel.ToList();
        }

        public static void AccessAllHardwareTables(Controller controller, ApplicationDbContext context)
        {
            controller.ViewData["Camera"] = context.Camera.ToList();
            controller.ViewData["DisplayTechnology"] = context.DisplayTechnology.ToList();
            controller.ViewData["Memory"] = context.Memory.ToList();
            controller.ViewData["StorageCapacity"] = context.StorageCapacity.ToList();
            controller.ViewData["USB"] = context.USB.ToList();
        }

        public static void AccessAllProductTables(Controller controller, ApplicationDbContext context)
        {
            controller.ViewData["Phone"] = context.Phone.ToList();
            controller.ViewData["Case"] = context.Case.ToList();
            controller.ViewData["Charger"] = context.Charger.ToList();
        }

        public static void AccessAllUserRelatedTables(Controller controller, ApplicationDbContext context)
        {
            controller.ViewData["ImageExtension"] = context.ImageExtensions.ToList();
        }
    }
}

