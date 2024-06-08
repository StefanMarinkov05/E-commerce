using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Models;
using ArtFusionStudio.Models.ProductFeatures.PhoneAccessories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtFusionStudio.Areas.Admin.Controllers
{
    public class SortingController : Controller
    {
       public static void SetProductSortingViewData(Controller controller, string sortOrder)
        {
            controller.ViewData["CurrentSort"] = sortOrder;
            controller.ViewData["IdSortParm"] = sortOrder == "id_asc" ? "id_desc" : "id_asc";
            controller.ViewData["NameSortParm"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            controller.ViewData["PriceSortParm"] = sortOrder == "price_asc" ? "price_desc" : "price_asc";
            controller.ViewData["RatingSortParm"] = sortOrder == "rating_asc" ? "rating_desc" : "rating_asc";
            controller.ViewData["TotalVotesSortParm"] = sortOrder == "total_votes_asc" ? "total_votes_desc" : "total_votes_asc";
        }

        public static void SetPhoneSortingViewData(Controller controller, string sortOrder)
        {
            controller.ViewData["CurrentSort"] = sortOrder;
            controller.ViewData["CapacitySortParm"] = sortOrder == "capacity_asc" ? "capacity_desc" : "capacity_asc";
            controller.ViewData["CamerasSortParm"] = sortOrder == "cameras_asc" ? "cameras_desc" : "cameras_asc";
            controller.ViewData["RAMSortParm"] = sortOrder == "ram_asc" ? "ram_desc" : "ram_asc";
        }
        public static void SetCaseSortingViewData(Controller controller, string sortOrder)
        {
            controller.ViewData["CurrentSort"] = sortOrder;
        }

        public static void SetChargerSortingViewData(Controller controller, string sortOrder)
        {
            controller.ViewData["CurrentSort"] = sortOrder;
        }


        public static IQueryable<Product> GetSortedProduct(ApplicationDbContext context, string sortOrder)
        {
            var Products = from p in context.Products
                           .Include(p => p.Brand)
                           .Include(p => p.Category)
                           select p;

            return SortProducts<Product>(Products, sortOrder);
        }

        public static IQueryable<Phone> GetSortedPhone(ApplicationDbContext context, string sortOrder)
        {
            var Products = GetSortedProduct(context, sortOrder);
            var Phones = from p in Products.OfType<Phone>()
                                 .Include(p => p.Camera)
                                 .Include(p => p.DisplayTechnology)
                                 .Include(p => p.OSNameAndVersion)
                                 .Include(p => p.Memory)
                                 .Include(p => p.StorageCapacity)
                                 .Include(p => p.USBType)
                         select p;

            return SortPhones<Phone>(Phones, sortOrder);
        }

        public static IQueryable<Case> GetSortedCases(ApplicationDbContext context, string sortOrder)
        {
            var Products = GetSortedProduct(context, sortOrder);
            var Cases = from c in Products.OfType<Case>()
                                 .Include(c => c.CaseMaterial)
                                 .Include(c => c.CaseType)
                                 .Include(c => c.ProtectionLevel)
                         select c;

            return SortCases<Case>(Cases, sortOrder);
        }

        public static IQueryable<Charger> GetSortedChargers(ApplicationDbContext context, string sortOrder)
        {
            var Products = GetSortedProduct(context, sortOrder);
            var Chargers = from c in Products.OfType<Charger>()
                           select c;

            return SortChargers<Charger>(Chargers, sortOrder);
        }

        public static IQueryable<T> SortProducts<T>(IQueryable<T> products, string sortOrder) where T : Product
        {
            return sortOrder switch
            {
                "id_desc" => products.OrderByDescending(p => p.Id),
                "name_desc" => products.OrderByDescending(p => p.Name),
                "price_desc" => products.OrderByDescending(p => p.CurrentPrice),
                "rating_desc" => products.OrderByDescending(p => Math.Round(((decimal)p.Score / (decimal)p.TotalVotes), 2)),
                "total_votes_desc" => products.OrderByDescending(p => p.TotalVotes),
                "id_asc" => products.OrderBy(p => p.Id),
                "name_asc" => products.OrderBy(p => p.Name),
                "price_asc" => products.OrderBy(p => p.CurrentPrice),
                "rating_asc" => products.OrderBy(p => Math.Round(((decimal)p.Score / (decimal)p.TotalVotes), 2)),
                "total_votes_asc" => products.OrderBy(p => p.TotalVotes),
                _ => products.OrderBy(p => p.Id)
            };
        }

        public static IQueryable<T> SortPhones<T>(IQueryable<T> phones, string sortOrder) where T : Phone
        {
            var sortedPhones = sortOrder switch
            {
                "capacity_desc" => phones.OrderByDescending(p => p.StorageCapacity.CapacityGB),
                "ram_desc" => phones.OrderByDescending(p => p.Memory.RAM),
                "cameras_desc" => phones.OrderByDescending(p => p.Camera.CameraCount),
                "capacity_asc" => phones.OrderBy(p => p.StorageCapacity.CapacityGB),
                "ram_asc" => phones.OrderBy(p => p.Memory.RAM),
                "cameras_asc" => phones.OrderBy(p => p.Camera.CameraCount),
                _ => phones.OrderBy(p => p.Id)
            };

            return SortProducts(sortedPhones.Cast<Phone>(), sortOrder).Cast<T>();
        }

        public static IQueryable<T> SortCases<T>(IQueryable<T> cases, string sortOrder) where T : Case
        {
            var sortedCases = sortOrder switch
            {
                _ => cases.OrderBy(c => c.Id)
            };

            return SortProducts(sortedCases.Cast<Case>(), sortOrder).Cast<T>();
        }

        public static IQueryable<T> SortChargers<T>(IQueryable<T> chargers, string sortOrder) where T : Charger
        {
            var sortedChargers = sortOrder switch
            {
                _ => chargers.OrderBy(c => c.Id)
            };

            return SortProducts(sortedChargers.Cast<Charger>(), sortOrder).Cast<T>();
        }
    }
}
