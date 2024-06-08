using ArtFusionStudio.Models;
using ArtFusionStudio.Models.ProductFeatures;
using ArtFusionStudio.Models.ProductFeatures.PhoneAccessories;
using ArtFusionStudio.Utility;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OSSnippet = ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.OperatingSystem;
using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures;
using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.Physical;
using System.Globalization;
using ArtFusionStudio.Models.Orders;

namespace ArtFusionStudio.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        
        public DbSet<Case> Case { get; set; }
        public DbSet<CaseMaterial> CaseMaterial { get; set; }
        public DbSet<CaseType> CaseType { get; set; }
        public DbSet<ProtectionLevel> ProtectionLevel { get; set; }

        public DbSet<Charger> Charger { get; set; }


        public DbSet<OSSnippet> OperatingSystems { get; set; }
        public DbSet<OperatingSystemVersion> OperatingSystemVersion { get; set; }
        public DbSet<OSNameAndVersion> OSNameAndVersion { get; set; }

        public DbSet<Coupon> Coupon { get; set; }

        public DbSet<Phone> Phone { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Camera> Camera { get; set; }
        public DbSet<Memory> Memory { get; set; }

        public DbSet<DisplayTechnology> DisplayTechnology { get; set; }
        public DbSet<StorageCapacity> StorageCapacity { get; set; } 
        public DbSet<USB> USB { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ImageExtension> ImageExtensions { get; set; }
        public DbSet<UserProfilePic> UserProfilePics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Phone" },
                new Category { Id = 2, Name = "Case" },
                new Category { Id = 3, Name = "Charger" }
                );

            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Iphone", PathD = BrandLogoPath.IPHONE_PATH },
                new Brand { Id = 2, Name = "Huawei", PathD = BrandLogoPath.HUAWEI_PATH },
                new Brand { Id = 3, Name = "Sony", PathD = BrandLogoPath.SONY_PATH },
                new Brand { Id = 4, Name = "Samsung", PathD = BrandLogoPath.SAMSUNG_PATH },
                new Brand { Id = 5, Name = "Nokia", PathD = BrandLogoPath.NOKIA_PATH },
                new Brand { Id = 6, Name = "Аксесоари", PathD = BrandLogoPath.ACCESSORIES_PATH },
                new Brand { Id = 7, Name = "Персонализирани", PathD = BrandLogoPath.CUSTOM_PATH }
                );

            modelBuilder.Entity<Camera>().HasData(
                new Camera { Id = 1, CameraCount = 1 },
                new Camera { Id = 2, CameraCount = 2 },
                new Camera { Id = 3, CameraCount = 3 },
                new Camera { Id = 4, CameraCount = 4 },
                new Camera { Id = 5, CameraCount = 5 },
                new Camera { Id = 6, CameraCount = 6 },
                new Camera { Id = 7, CameraCount = 7 }
                );

            modelBuilder.Entity<OSSnippet>().HasData(
                new OSSnippet { Id = 1, OSName = "Android" },
                new OSSnippet { Id = 2, OSName = "iOS" },
                new OSSnippet { Id = 3, OSName = "HarmonyOS" },
                new OSSnippet { Id = 4, OSName = "MIUI" },
                new OSSnippet { Id = 5, OSName = "One UI" },
                new OSSnippet { Id = 6, OSName = "Windows Phone" }
                );

            modelBuilder.Entity<OperatingSystemVersion>().HasData(
                new OperatingSystemVersion { Id = 1, OSVersion = 1.0m },
                new OperatingSystemVersion { Id = 2, OSVersion = 2.0m },
                new OperatingSystemVersion { Id = 3, OSVersion = 3.0m },
                new OperatingSystemVersion { Id = 4, OSVersion = 4.0m },
                new OperatingSystemVersion { Id = 5, OSVersion = 5.0m },
                new OperatingSystemVersion { Id = 6, OSVersion = 5.5m },
                new OperatingSystemVersion { Id = 7, OSVersion = 6.0m },
                new OperatingSystemVersion { Id = 8, OSVersion = 7.0m },
                new OperatingSystemVersion { Id = 9, OSVersion = 8.0m },
                new OperatingSystemVersion { Id = 10, OSVersion = 9.0m },
                new OperatingSystemVersion { Id = 11, OSVersion = 10.0m },
                new OperatingSystemVersion { Id = 12, OSVersion = 11.0m },
                new OperatingSystemVersion { Id = 13, OSVersion = 12.0m },
                new OperatingSystemVersion { Id = 14, OSVersion = 12.5m },
                new OperatingSystemVersion { Id = 15, OSVersion = 13.0m },
                new OperatingSystemVersion { Id = 16, OSVersion = 14.0m },
                new OperatingSystemVersion { Id = 17, OSVersion = 15.0m },
                new OperatingSystemVersion { Id = 18, OSVersion = 16.0m },
                new OperatingSystemVersion { Id = 19, OSVersion = 17.0m }
                );

            modelBuilder.Entity<OSNameAndVersion>().HasData(
                new OSNameAndVersion { Id = 1, OSNameId = 1, OSVersionId = 1 },
                new OSNameAndVersion { Id = 2, OSNameId = 1, OSVersionId = 2 },
                new OSNameAndVersion { Id = 3, OSNameId = 1, OSVersionId = 3 },
                new OSNameAndVersion { Id = 4, OSNameId = 1, OSVersionId = 4 },
                new OSNameAndVersion { Id = 5, OSNameId = 1, OSVersionId = 5 },
                new OSNameAndVersion { Id = 6, OSNameId = 1, OSVersionId = 7 },
                new OSNameAndVersion { Id = 7, OSNameId = 1, OSVersionId = 8 },
                new OSNameAndVersion { Id = 8, OSNameId = 1, OSVersionId = 9 },
                new OSNameAndVersion { Id = 9, OSNameId = 1, OSVersionId = 10 },
                new OSNameAndVersion { Id = 10, OSNameId = 1, OSVersionId = 11 },
                new OSNameAndVersion { Id = 11, OSNameId = 1, OSVersionId = 12 },
                new OSNameAndVersion { Id = 12, OSNameId = 1, OSVersionId = 13 },
                new OSNameAndVersion { Id = 13, OSNameId = 2, OSVersionId = 1 },
                new OSNameAndVersion { Id = 14, OSNameId = 2, OSVersionId = 2 },
                new OSNameAndVersion { Id = 15, OSNameId = 2, OSVersionId = 3 },
                new OSNameAndVersion { Id = 16, OSNameId = 2, OSVersionId = 4 },
                new OSNameAndVersion { Id = 17, OSNameId = 2, OSVersionId = 5 },
                new OSNameAndVersion { Id = 18, OSNameId = 2, OSVersionId = 7 },
                new OSNameAndVersion { Id = 19, OSNameId = 2, OSVersionId = 8 },
                new OSNameAndVersion { Id = 20, OSNameId = 2, OSVersionId = 9 },
                new OSNameAndVersion { Id = 21, OSNameId = 2, OSVersionId = 10 },
                new OSNameAndVersion { Id = 22, OSNameId = 2, OSVersionId = 11 },
                new OSNameAndVersion { Id = 23, OSNameId = 2, OSVersionId = 12 },
                new OSNameAndVersion { Id = 24, OSNameId = 2, OSVersionId = 13 },
                new OSNameAndVersion { Id = 25, OSNameId = 2, OSVersionId = 15 },
                new OSNameAndVersion { Id = 26, OSNameId = 2, OSVersionId = 16 },
                new OSNameAndVersion { Id = 27, OSNameId = 2, OSVersionId = 17 },
                new OSNameAndVersion { Id = 28, OSNameId = 2, OSVersionId = 18 },
                new OSNameAndVersion { Id = 29, OSNameId = 2, OSVersionId = 19 },
                new OSNameAndVersion { Id = 30, OSNameId = 3, OSVersionId = 1 },
                new OSNameAndVersion { Id = 31, OSNameId = 3, OSVersionId = 2 },
                new OSNameAndVersion { Id = 32, OSNameId = 3, OSVersionId = 3 },
                new OSNameAndVersion { Id = 33, OSNameId = 3, OSVersionId = 4 },
                new OSNameAndVersion { Id = 34, OSNameId = 3, OSVersionId = 5 },
                new OSNameAndVersion { Id = 35, OSNameId = 4, OSVersionId = 1 },
                new OSNameAndVersion { Id = 36, OSNameId = 4, OSVersionId = 2 },
                new OSNameAndVersion { Id = 37, OSNameId = 4, OSVersionId = 3 },
                new OSNameAndVersion { Id = 38, OSNameId = 4, OSVersionId = 4 },
                new OSNameAndVersion { Id = 39, OSNameId = 4, OSVersionId = 5 },
                new OSNameAndVersion { Id = 40, OSNameId = 4, OSVersionId = 7 },
                new OSNameAndVersion { Id = 41, OSNameId = 4, OSVersionId = 8 },
                new OSNameAndVersion { Id = 42, OSNameId = 4, OSVersionId = 9 },
                new OSNameAndVersion { Id = 43, OSNameId = 4, OSVersionId = 10 },
                new OSNameAndVersion { Id = 44, OSNameId = 4, OSVersionId = 11 },
                new OSNameAndVersion { Id = 45, OSNameId = 4, OSVersionId = 12 },
                new OSNameAndVersion { Id = 46, OSNameId = 4, OSVersionId = 13 },
                new OSNameAndVersion { Id = 47, OSNameId = 4, OSVersionId = 14 },
                new OSNameAndVersion { Id = 48, OSNameId = 4, OSVersionId = 15 },
                new OSNameAndVersion { Id = 49, OSNameId = 5, OSVersionId = 1 },
                new OSNameAndVersion { Id = 50, OSNameId = 5, OSVersionId = 2 },
                new OSNameAndVersion { Id = 51, OSNameId = 5, OSVersionId = 3 },
                new OSNameAndVersion { Id = 52, OSNameId = 5, OSVersionId = 4 },
                new OSNameAndVersion { Id = 53, OSNameId = 5, OSVersionId = 5 },
                new OSNameAndVersion { Id = 54, OSNameId = 5, OSVersionId = 7 },
                new OSNameAndVersion { Id = 55, OSNameId = 6, OSVersionId = 8 },
                new OSNameAndVersion { Id = 56, OSNameId = 6, OSVersionId = 9 },
                new OSNameAndVersion { Id = 57, OSNameId = 6, OSVersionId = 11 }
                );

            modelBuilder.Entity<Memory>().HasData(
                new Memory { Id = 1, RAM = 1 },
                new Memory { Id = 2, RAM = 2 },
                new Memory { Id = 3, RAM = 3 },
                new Memory { Id = 4, RAM = 4 },
                new Memory { Id = 5, RAM = 5 },
                new Memory { Id = 6, RAM = 6 },
                new Memory { Id = 7, RAM = 7 },
                new Memory { Id = 8, RAM = 8 },
                new Memory { Id = 9, RAM = 10 },
                new Memory { Id = 10, RAM = 12 },
                new Memory { Id = 11, RAM = 14 },
                new Memory { Id = 12, RAM = 16 },
                new Memory { Id = 13, RAM = 18 },
                new Memory { Id = 14, RAM = 20 },
                new Memory { Id = 15, RAM = 22 },
                new Memory { Id = 16, RAM = 24 },
                new Memory { Id = 17, RAM = 26 },
                new Memory { Id = 18, RAM = 28 }
                );

            modelBuilder.Entity<StorageCapacity>().HasData(
                new StorageCapacity { Id = 1, CapacityGB = 8 },
                new StorageCapacity { Id = 2, CapacityGB = 12 },
                new StorageCapacity { Id = 3, CapacityGB = 16 },
                new StorageCapacity { Id = 4, CapacityGB = 24 },
                new StorageCapacity { Id = 5, CapacityGB = 32 },
                new StorageCapacity { Id = 6, CapacityGB = 48 },
                new StorageCapacity { Id = 7, CapacityGB = 64 },
                new StorageCapacity { Id = 8, CapacityGB = 86 },
                new StorageCapacity { Id = 9, CapacityGB = 128 },
                new StorageCapacity { Id = 10, CapacityGB = 196 },
                new StorageCapacity { Id = 11, CapacityGB = 256 },
                new StorageCapacity { Id = 12, CapacityGB = 384 },
                new StorageCapacity { Id = 13, CapacityGB = 420 },
                new StorageCapacity { Id = 14, CapacityGB = 512 },
                new StorageCapacity { Id = 15, CapacityGB = 786 },
                new StorageCapacity { Id = 16, CapacityGB = 1024 }
                );

            modelBuilder.Entity<USB>().HasData(
                new USB { Id = 1, Type = "USB-A" },
                new USB { Id = 2, Type = "USB-B" },
                new USB { Id = 3, Type = "USB-C" },
                new USB { Id = 4, Type = "Mini-USB" },
                new USB { Id = 5, Type = "Micro-USB" },
                new USB { Id = 6, Type = "Lightning" }
                );

            modelBuilder.Entity<CaseMaterial>().HasData(
                new CaseMaterial { Id = 1, Name = "Силикон" },
                new CaseMaterial { Id = 2, Name = "Дърво" },
                new CaseMaterial { Id = 3, Name = "Плат" },
                new CaseMaterial { Id = 4, Name = "Силикон" },
                new CaseMaterial { Id = 5, Name = "Пластмаса" },
                new CaseMaterial { Id = 6, Name = "TPU" },
                new CaseMaterial { Id = 7, Name = "Гума" },
                new CaseMaterial { Id = 8, Name = "Метал" },
                new CaseMaterial { Id = 9, Name = "Поликарбон" }
                );

            modelBuilder.Entity<CaseType>().HasData(
                new CaseType { Id = 1, Name = "Портфейл" },
                new CaseType { Id = 2, Name = "Само гръб" },
                new CaseType { Id = 3, Name = "Скелет" },
                new CaseType { Id = 4, Name = "Вертикален" },
                new CaseType { Id = 5, Name = "С батерия" },
                new CaseType { Id = 6, Name = "Ръчен" },
                new CaseType { Id = 7, Name = "Удароустойчив" },
                new CaseType { Id = 8, Name = "Водоустойчив" },
                new CaseType { Id = 9, Name = "Чанта" },
                new CaseType { Id = 10, Name = "Кобур" }
                );

            modelBuilder.Entity<ProtectionLevel>().HasData(
                new ProtectionLevel { Id = 1, Protection = "Екстремно" },
                new ProtectionLevel { Id = 2, Protection = "Здраво" },
                new ProtectionLevel { Id = 3, Protection = "Средно" },
                new ProtectionLevel { Id = 4, Protection = "Слабо" }
                );

            modelBuilder.Entity<DisplayTechnology>().HasData(
                new DisplayTechnology { Id = 1, Name = "LCD" },
                new DisplayTechnology { Id = 2, Name = "LED" },
                new DisplayTechnology { Id = 3, Name = "Mini LED" },
                new DisplayTechnology { Id = 4, Name = "OLED" },
                new DisplayTechnology { Id = 5, Name = "POLED" },
                new DisplayTechnology { Id = 6, Name = "AMOLED" },
                new DisplayTechnology { Id = 7, Name = "Retina" }
                );

            modelBuilder.Entity<Phone>().HasData(
                new Phone { Id = 1, CategoryId = 1, BrandId = 1, ProductURL = "iphone_15_pro.png", Name = "Iphone 15 Pro", Description = "Вече има нещо по-твърдо от легендарната Nokia 3220", OldPrice = 2999.99m, CurrentPrice = 2699.99m, DisplayTechnologyId = 4, USBTypeId = 3, CamerasId = 5, StorageCapacityId = 14, RAMMemoryId = 8, OSNameAndVersionId = 29, Score = 1202, TotalVotes = 251, Quantity = 142 },
                new Phone { Id = 2, CategoryId = 1, BrandId = 2, ProductURL = "huawei_p40_pro.png", Name = "Huawei P40 Pro", Description = "Водещ смартфон от Huawei", OldPrice = 899.99m, CurrentPrice = 799.99m, DisplayTechnologyId = 4, USBTypeId = 3, CamerasId = 5, OSNameAndVersionId = 18, Score = 167, StorageCapacityId = 6, RAMMemoryId = 8, TotalVotes = 35, Quantity = 72 },
                new Phone { Id = 3, CategoryId = 1, BrandId = 3, ProductURL = "sony_xperia_1_ii.png", Name = "Sony Xperia 1 II", Description = "Висок клас смартфон, проектиран за мултимедия", OldPrice = 1099.99m, CurrentPrice = 999.99m, DisplayTechnologyId = 3, USBTypeId = 3, CamerasId = 4, OSNameAndVersionId = 3, Score = 1842, StorageCapacityId = 12, RAMMemoryId = 9, TotalVotes = 420, Quantity = 205 },
                new Phone { Id = 4, CategoryId = 1, BrandId = 4, ProductURL = "samsung_galaxy_s21_ultra.png", Name = "Samsung Galaxy S21 Ultra", Description = "Най-висок клас смартфон със завършени функции", OldPrice = 1299.99m, CurrentPrice = 1199.99m, DisplayTechnologyId = 5, USBTypeId = 3, CamerasId = 5, OSNameAndVersionId = 18, Score = 27, StorageCapacityId = 14, RAMMemoryId = 10, TotalVotes = 7, Quantity = 103 },
                new Phone { Id = 5, CategoryId = 1, BrandId = 5, ProductURL = "nokia_9_pureview.png", Name = "Nokia 9 PureView", Description = "Иновативен смартфон с акцент върху качеството на камерата", OldPrice = 699.99m, CurrentPrice = 599.99m, DisplayTechnologyId = 4, USBTypeId = 3, CamerasId = 1, OSNameAndVersionId = 3, Score = 107, StorageCapacityId = 7, RAMMemoryId = 6, TotalVotes = 26, Quantity = 221 },
                new Phone { Id = 6, CategoryId = 1, BrandId = 1, ProductURL = "iphone_14_pro.png", Name = "iPhone 14 Pro", Description = "Най-големият и най-мощният iPhone досега", OldPrice = 1299.99m, CurrentPrice = 1199.99m, DisplayTechnologyId = 6, USBTypeId = 3, CamerasId = 5, OSNameAndVersionId = 6, Score = 108, StorageCapacityId = 10, RAMMemoryId = 7, TotalVotes = 40, Quantity = 45 },
                new Phone { Id = 7, CategoryId = 1, BrandId = 2, ProductURL = "huawei_mate_x3.png", Name = "Huawei Mate X3", Description = "Премиум смартфон с изкуство на режещата технология", OldPrice = 999.99m, CurrentPrice = 899.99m, DisplayTechnologyId = 5, USBTypeId = 3, CamerasId = 5, OSNameAndVersionId = 18, Score = 317, StorageCapacityId = 9, RAMMemoryId = 7, TotalVotes = 88, Quantity = 147 },
                new Phone { Id = 8, CategoryId = 1, BrandId = 3, ProductURL = "sony_xperia_5_ii.png", Name = "Sony Xperia 5 II", Description = "Компактен, но мощен смартфон за игри и мултимедия", OldPrice = 899.99m, CurrentPrice = 799.99m, DisplayTechnologyId = 2, USBTypeId = 3, CamerasId = 4, OSNameAndVersionId = 3, Score = 340, StorageCapacityId = 11, RAMMemoryId = 9, TotalVotes = 100, Quantity = 38 },
                new Phone { Id = 9, CategoryId = 1, BrandId = 4, ProductURL = "samsung_s24.png", Name = "Samsung S24", Description = "Флагмански фаблет с функционалност на S Pen", OldPrice = 1199.99m, CurrentPrice = 1099.99m, DisplayTechnologyId = 6, USBTypeId = 3, CamerasId = 5, OSNameAndVersionId = 18, Score = 793, StorageCapacityId = 15, RAMMemoryId = 10, TotalVotes = 169, Quantity = 184 },
                new Phone { Id = 10, CategoryId = 1, BrandId = 5, ProductURL = "nokia_g42.png", Name = "Nokia G42", Description = "5G-съвместим смартфон с технология PureDisplay", OldPrice = 699.99m, CurrentPrice = 599.99m, DisplayTechnologyId = 7, USBTypeId = 3, CamerasId = 4, OSNameAndVersionId = 3, Score = 936, StorageCapacityId = 5, RAMMemoryId = 8, TotalVotes = 195, Quantity = 196 },
                new Phone { Id = 11, CategoryId = 1, BrandId = 1, ProductURL = "iphone_se.png", Name = "iPhone SE", Description = "Компактен и достъпен модел iPhone", OldPrice = 399.99m, CurrentPrice = 349.99m, DisplayTechnologyId = 5, USBTypeId = 3, CamerasId = 2, OSNameAndVersionId = 6, Score = 242, StorageCapacityId = 2, RAMMemoryId = 11, TotalVotes = 69, Quantity = 189 },
                new Phone { Id = 12, CategoryId = 1, BrandId = 2, ProductURL = "huawei_p60.png", Name = "Huawei P60", Description = "Предишен флагман с впечатляващи възможности на камерата", OldPrice = 799.99m, CurrentPrice = 699.99m, DisplayTechnologyId = 1, USBTypeId = 3, CamerasId = 4, OSNameAndVersionId = 18, Score = 119, StorageCapacityId = 4, RAMMemoryId = 8, TotalVotes = 35, Quantity = 35 },
                new Phone { Id = 13, CategoryId = 1, BrandId = 3, ProductURL = "sony_xperia.png", Name = "Sony Xperia", Description = "Стройен смартфон с върхови мултимедийни възможности", OldPrice = 799.99m, CurrentPrice = 699.99m, DisplayTechnologyId = 3, USBTypeId = 3, CamerasId = 3, OSNameAndVersionId = 3, Score = 37, StorageCapacityId = 3, RAMMemoryId = 5, TotalVotes = 17, Quantity = 127 },
                new Phone { Id = 14, CategoryId = 1, BrandId = 4, ProductURL = "samsung_galaxy_z.png", Name = "Samsung Galaxy Z", Description = "Достъпен смартфон с разнообразни възможности на камерата", OldPrice = 499.99m, CurrentPrice = 449.99m, DisplayTechnologyId = 3, USBTypeId = 3, CamerasId = 3, OSNameAndVersionId = 18, Score = 176, StorageCapacityId = 13, RAMMemoryId = 7, TotalVotes = 42, Quantity = 35 },
                new Phone { Id = 15, CategoryId = 1, BrandId = 5, ProductURL = "nokia_c210.png", Name = "Nokia c210", Description = "Стилен смартфон с Zeiss Optics", OldPrice = 399.99m, CurrentPrice = 349.99m, DisplayTechnologyId = 3, USBTypeId = 3, CamerasId = 2, OSNameAndVersionId = 3, Score = 200, StorageCapacityId = 1, RAMMemoryId = 5, TotalVotes = 69, Quantity = 78 },
                new Phone { Id = 16, CategoryId = 1, BrandId = 1, ProductURL = "iphone_xr.png", Name = "iPhone XR", Description = "Цветен и бюджетен модел iPhone", OldPrice = 599.99m, CurrentPrice = 549.99m, DisplayTechnologyId = 3, USBTypeId = 6, CamerasId = 2, OSNameAndVersionId = 6, Score = 48, StorageCapacityId = 16, RAMMemoryId = 8, TotalVotes = 12, Quantity = 12 },
                new Phone { Id = 17, CategoryId = 1, BrandId = 2, ProductURL = "huawei_nova_7.png", Name = "Huawei nova 7", Description = "Стилен смартфон с фокус върху селфитата", OldPrice = 499.99m, CurrentPrice = 449.99m, DisplayTechnologyId = 3, USBTypeId = 3, CamerasId = 3, OSNameAndVersionId = 18, Score = 299, StorageCapacityId = 8, RAMMemoryId = 7, TotalVotes = 73, Quantity = 201 },
                new Phone { Id = 18, CategoryId = 1, BrandId = 3, ProductURL = "sony_xperia_10.png", Name = "Sony Xperia 10", Description = "Достъпен смартфон с висок дисплей", OldPrice = 349.99m, CurrentPrice = 299.99m, DisplayTechnologyId = 3, USBTypeId = 3, CamerasId = 2, OSNameAndVersionId = 3, Score = 182, StorageCapacityId = 2, RAMMemoryId = 4, TotalVotes = 48, Quantity = 145 }
            );


            modelBuilder.Entity<Charger>().HasData(
                new Charger { Id = 19, CategoryId = 3, BrandId = 1, ProductURL = "fast_charging_adapter.png", Name = "Зареждащ адаптер", Description = "Високоскоростен зарядно за различни устройства.", OldPrice = 15.99m, CurrentPrice = 12.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = true, TotalVotes = 125, Score = 327, Quantity = 256 },
                new Charger { Id = 20, CategoryId = 3, BrandId = 6, ProductURL = "universal_usb_charger.png", Name = "Универсално USB зарядно", Description = "Компактно зарядно с множество USB портове.", OldPrice = 12.49m, CurrentPrice = 9.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = false, TotalVotes = 234, Score = 522, Quantity = 512 },
                new Charger { Id = 21, CategoryId = 3, BrandId = 2, ProductURL = "samsung_fast_charging_pad.png", Name = "Зареждаща подложка Samsung", Description = "Безжично зареждане за Samsung устройства.", OldPrice = 24.99m, CurrentPrice = 19.99m, OutputCurrent = 1, OutputVoltage = 9, FastChargingSupported = true, TotalVotes = 143, Score = 312, Quantity = 128 },
                new Charger { Id = 22, CategoryId = 3, BrandId = 1, ProductURL = "iphone_wireless_charging_pad.png", Name = "Безжична зареждаща подложка за iPhone", Description = "Зареждайте своя iPhone безжично с тази стилна подложка.", OldPrice = 29.99m, CurrentPrice = 24.99m, OutputCurrent = 1, OutputVoltage = 9, FastChargingSupported = true, TotalVotes = 216, Score = 497, Quantity = 64 },
                new Charger { Id = 23, CategoryId = 3, BrandId = 3, ProductURL = "huawei_quick_charge_adapter.png", Name = "Зареждащ адаптер за Huawei", Description = "Оригинален зарядно за бързо зареждане на вашето устройство Huawei.", OldPrice = 19.99m, CurrentPrice = 15.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = true, TotalVotes = 159, Score = 372, Quantity = 256 },
                new Charger { Id = 24, CategoryId = 3, BrandId = 6, ProductURL = "multi_port_charging_station.png", Name = "Мултипортово зарядно", Description = "Зареждайте едновременно няколко устройства с тази зарядна станция.", OldPrice = 39.99m, CurrentPrice = 34.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = false, TotalVotes = 184, Score = 425, Quantity = 128 },
                new Charger { Id = 25, CategoryId = 3, BrandId = 2, ProductURL = "samsung_wireless_charging_stand.png", Name = "Безжична зареждаща стойка Samsung", Description = "Зареждайте своя Samsung удобно с тази безжична стойка.", OldPrice = 27.99m, CurrentPrice = 22.99m, OutputCurrent = 1, OutputVoltage = 9, FastChargingSupported = true, TotalVotes = 178, Score = 416, Quantity = 512 },
                new Charger { Id = 26, CategoryId = 3, BrandId = 1, ProductURL = "iphone_fast_charging_block.png", Name = "Зареждащ блок за iPhone", Description = "Оригинален блок за бързо зареждане на вашето устройство iPhone.", OldPrice = 18.99m, CurrentPrice = 14.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = true, TotalVotes = 197, Score = 456, Quantity = 256 },
                new Charger { Id = 27, CategoryId = 3, BrandId = 5, ProductURL = "nokia_usb_c_charger.png", Name = "USB с зарядно за Nokia", Description = "Зареждайте своя Nokia устройства бързо и сигурно с това USB C зарядно.", OldPrice = 14.99m, CurrentPrice = 11.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = true, TotalVotes = 168, Score = 391, Quantity = 256 },
                new Charger { Id = 28, CategoryId = 3, BrandId = 1, ProductURL = "iphone_magsafe_charger.png", Name = "MagSafe зареждащо ъстройство за iPhone", Description = "зареждане и стабилна връзка с този MagSafe зарядно.", OldPrice = 39.99m, CurrentPrice = 34.99m, OutputCurrent = 1, OutputVoltage = 9, FastChargingSupported = true, TotalVotes = 122, Score = 307, Quantity = 128 },
                new Charger { Id = 29, CategoryId = 3, BrandId = 6, ProductURL = "fast_charging_power_bank.png", Name = "Зареждащ Power Bank", Description = "Преносим заряден резервоар за вашите устройства с бързо зареждане.", OldPrice = 29.99m, CurrentPrice = 24.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = true, TotalVotes = 135, Score = 337, Quantity = 512 },
                new Charger { Id = 30, CategoryId = 3, BrandId = 3, ProductURL = "huawei_super_charge_car_charger.png", Name = "Зарядно за кола Huawei Super Charge", Description = "Зареждане, докато сте в движение с това автомобилно зарядно устройство.", OldPrice = 17.99m, CurrentPrice = 14.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = true, TotalVotes = 149, Score = 356, Quantity = 256 },
                new Charger { Id = 31, CategoryId = 3, BrandId = 1, ProductURL = "iphone_magnetic_wireless_charger.png", Name = "Магнитен Безжичен Зарядчик за iPhone", Description = "и лесно зареждане с този магнитен безжичен зарядчик.", OldPrice = 22.99m, CurrentPrice = 18.99m, OutputCurrent = 1, OutputVoltage = 9, FastChargingSupported = true, TotalVotes = 157, Score = 368, Quantity = 128 },
                new Charger { Id = 32, CategoryId = 3, BrandId = 2, ProductURL = "samsung_wireless_power_bank.png", Name = "Безжичен Power Bank за Samsung", Description = "Зареждайте вашите Samsung устройства безжично и на пътя.", OldPrice = 34.99m, CurrentPrice = 29.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = true, TotalVotes = 132, Score = 325, Quantity = 512 },
                new Charger { Id = 33, CategoryId = 3, BrandId = 6, ProductURL = "quick_charge_usb_c_adapter.png", Name = "USB с зарядно", Description = "Зареждайте своите устройства бързо и ефективно с това зарядно устройство.", OldPrice = 19.99m, CurrentPrice = 15.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = true, TotalVotes = 141, Score = 348, Quantity = 256 },
                new Charger { Id = 34, CategoryId = 3, BrandId = 1, ProductURL = "iphone_magsafe_car_mount_charger.png", Name = "MagSafe автомобилно монтирано зарядно за iPhone", Description = "Зареждайте своя iPhone в колата с това удобно зарядно.", OldPrice = 29.99m, CurrentPrice = 24.99m, OutputCurrent = 1, OutputVoltage = 9, FastChargingSupported = true, TotalVotes = 169, Score = 388, Quantity = 128 },
                new Charger { Id = 35, CategoryId = 3, BrandId = 3, ProductURL = "huawei_super_charge_wall_charger.png", Name = "Huawei Super Charge стенно зарядно", Description = "и ефективно зареждане за вашите Huawei устройства с това стенно зарядно.", OldPrice = 14.99m, CurrentPrice = 11.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = true, TotalVotes = 128, Score = 332, Quantity = 256 },
                new Charger { Id = 36, CategoryId = 3, BrandId = 5, ProductURL = "nokia_fast_charging_cable.png", Name = "Зареждащ кабел за Nokia", Description = "Компактен и бърз кабел за зареждане на вашите Nokia устройства.", OldPrice = 9.99m, CurrentPrice = 7.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = true, TotalVotes = 152, Score = 361, Quantity = 512 },
                new Charger { Id = 37, CategoryId = 3, BrandId = 1, ProductURL = "iphone_pd_charger.png", Name = "iPhone PD зарядно", Description = "Power Delivery зарядно за вашето iPhone с бързо зареждане.", OldPrice = 29.99m, CurrentPrice = 24.99m, OutputCurrent = 2, OutputVoltage = 5, FastChargingSupported = true, TotalVotes = 145, Score = 355, Quantity = 256 }
            );


            modelBuilder.Entity<Case>().HasData(
                new Case { Id = 38, CategoryId = 2, BrandId = 3, ProductURL = "sony_xperia_5_case.png", Name = "Кожен калъф с портмоне за Sony Xperia 5", Description = "Премиум кожен калъф с отделения за карти за Sony Xperia 5, предлагащ защита и функционалност.", OldPrice = 24.99m, CurrentPrice = 19.99m, CaseMaterialId = 6, CaseTypeId = 5, ProtectionLevelId = 3, TotalVotes = 50, Score = 200, Quantity = 128 },
                new Case { Id = 39, CategoryId = 2, BrandId = 4, ProductURL = "samsung_galaxy_s20_case.png", Name = "Калъф Armor за Samsung Galaxy S20", Description = "Здрав и издръжлив калъф Armor за Samsung Galaxy S20 със стилен дизайн и отлични възможности за абсорбиране на удари.", OldPrice = 21.99m, CurrentPrice = 16.99m, CaseMaterialId = 2, CaseTypeId = 3, ProtectionLevelId = 3, TotalVotes = 45, Score = 190, Quantity = 256 },
                new Case { Id = 40, CategoryId = 2, BrandId = 5, ProductURL = "nokia_7_2_case.png", Name = "Хибриден калъф за Nokia 7.2", Description = "Хибриден калъф за Nokia 7.2, комбиниращ твърд гръб от PC с гъвкав TPU бампер за двоен защитен слой срещу удари и счупвания.", OldPrice = 18.99m, CurrentPrice = 13.99m, CaseMaterialId = 3, CaseTypeId = 2, ProtectionLevelId = 2, TotalVotes = 42, Score = 160, Quantity = 64 },
                new Case { Id = 41, CategoryId = 2, BrandId = 5, ProductURL = "nokia_9_pureview_case.png", Name = "Модерен калъф за Nokia 9 PureView", Description = "Уникален калъф с геометричен дизайн за Nokia 9 PureView, предпазващ го от надрасквания и падания.", OldPrice = 22.99m, CurrentPrice = 17.99m, CaseMaterialId = 5, CaseTypeId = 2, ProtectionLevelId = 3, TotalVotes = 55, Score = 160, Quantity = 256 },
                new Case { Id = 42, CategoryId = 2, BrandId = 4, ProductURL = "samsung_galaxy_a72_case.png", Name = "Силиконов калъф за Samsung Galaxy A72", Description = "Удобен и гъвкав калъф за Samsung Galaxy A72, осигуряващ защита от удари и надрасквания.", OldPrice = 19.99m, CurrentPrice = 15.99m, CaseMaterialId = 1, CaseTypeId = 2, ProtectionLevelId = 3, TotalVotes = 60, Score = 170, Quantity = 128 },
                new Case { Id = 43, CategoryId = 2, BrandId = 3, ProductURL = "sony_xperia_10_ii_case.png", Name = "Луксозен калъф за Sony Xperia 10 II", Description = "Елегантен калъф от естествена кожа за Sony Xperia 10 II, с дискретен лого на бранда.", OldPrice = 21.99m, CurrentPrice = 16.99m, CaseMaterialId = 8, CaseTypeId = 2, ProtectionLevelId = 3, TotalVotes = 70, Score = 210, Quantity = 256 },
                new Case { Id = 44, CategoryId = 2, BrandId = 4, ProductURL = "samsung_galaxy_s21_case.png", Name = "Спортен калъф за Samsung Galaxy S21", Description = "Лек и гъвкав калъф за Samsung Galaxy S21, идеален за фитнес и спортни занимания.", OldPrice = 27.99m, CurrentPrice = 21.99m, CaseMaterialId = 1, CaseTypeId = 3, ProtectionLevelId = 2, TotalVotes = 60, Score = 180, Quantity = 64 },
                new Case { Id = 45, CategoryId = 2, BrandId = 2, ProductURL = "huawei_mate_40_case.png", Name = "Антишок калъф за Huawei Mate 40", Description = "Калъф с двойна защита за Huawei Mate 40, предпазващ го от удари и надрасквания.", OldPrice = 26.99m, CurrentPrice = 20.99m, CaseMaterialId = 7, CaseTypeId = 3, ProtectionLevelId = 3, TotalVotes = 48, Score = 140, Quantity = 256 },
                new Case { Id = 46, CategoryId = 2, BrandId = 1, ProductURL = "iphone_12_pro_case.png", Name = "Кожен калъф за iPhone 12 Pro", Description = "Ръчно изработен кожен калъф за iPhone 12 Pro, с вграден магнит за по-сигурно затваряне.", OldPrice = 29.99m, CurrentPrice = 19.99m, CaseMaterialId = 1, CaseTypeId = 1, ProtectionLevelId = 2, TotalVotes = 50, Score = 110, Quantity = 256 },
                new Case { Id = 47, CategoryId = 2, BrandId = 5, ProductURL = "nokia_3310_case.png", Name = "Метален калъф за Nokia 3310", Description = "Универсален калъф за съхранение на различни аксесоари като слушалки, зарядни и USB кабели.", OldPrice = 14.99m, CurrentPrice = 11.99m, CaseMaterialId = 8, CaseTypeId = 10, ProtectionLevelId = 1, TotalVotes = 42, Score = 144, Quantity = 256 },
                new Case { Id = 48, CategoryId = 2, BrandId = 5, ProductURL = "nokia_8_3_case.png", Name = "Спортен калъф за Nokia 8.3", Description = "Лек и гъвкав калъф за Nokia 8.3, идеален за спорт и фитнес занимания.", OldPrice = 19.99m, CurrentPrice = 15.99m, CaseMaterialId = 4, CaseTypeId = 3, ProtectionLevelId = 2, TotalVotes = 40, Score = 160, Quantity = 128 },
                new Case { Id = 49, CategoryId = 2, BrandId = 1, ProductURL = "iphone_se_case.png", Name = "Стилен калъф за iPhone SE", Description = "Елегантен калъф за iPhone SE, изработен от качествени материали и със стилно лого на Apple.", OldPrice = 22.99m, CurrentPrice = 18.99m, CaseMaterialId = 6, CaseTypeId = 1, ProtectionLevelId = 3, TotalVotes = 55, Score = 220, Quantity = 256 },
                new Case { Id = 50, CategoryId = 2, BrandId = 6, ProductURL = "custom_case_02.png", Name = "Персонализиран калъф", Description = "Персонализиран калъф с избрана от вас снимка или дизайн, създаден специално за вашия телефон.", OldPrice = 25.99m, CurrentPrice = 21.99m, CaseMaterialId = 1, CaseTypeId = 2, ProtectionLevelId = 3, TotalVotes = 50, Score = 200, Quantity = 128 },
                new Case { Id = 51, CategoryId = 2, BrandId = 4, ProductURL = "samsung_galaxy_a51_case.png", Name = "Грапав калъф за Samsung Galaxy A51", Description = "Калъф с грапава повърхност за по-добро захващане на Samsung Galaxy A51, съчетаващ защита и стил.", OldPrice = 21.99m, CurrentPrice = 16.99m, CaseMaterialId = 8, CaseTypeId = 2, ProtectionLevelId = 2, TotalVotes = 60, Score = 240, Quantity = 64 },
                new Case { Id = 52, CategoryId = 2, BrandId = 6, ProductURL = "accessories_case_03.png", Name = "Компактен калъф за аксесоари", Description = "Компактен калъф за съхранение на различни аксесоари като кабели, USB устройства и зарядни устройства.", OldPrice = 14.99m, CurrentPrice = 11.99m, CaseMaterialId = 6, CaseTypeId = 9, ProtectionLevelId = 2, TotalVotes = 35, Score = 140, Quantity = 256 },
                new Case { Id = 53, CategoryId = 2, BrandId = 3, ProductURL = "sony_xperia_1_ii_case.png", Name = "Водоустойчив калъф за Sony Xperia 1 II", Description = "Калъф с водоустойчива защита за Sony Xperia 1 II, предпазващ го от вода и влага.", OldPrice = 26.99m, CurrentPrice = 20.99m, CaseMaterialId = 7, CaseTypeId = 8, ProtectionLevelId = 3, TotalVotes = 45, Score = 180, Quantity = 256 },
                new Case { Id = 54, CategoryId = 2, BrandId = 2, ProductURL = "huawei_mate_30_pro_case.png", Name = "Страничен калъф за Huawei Mate 30 Pro", Description = "Калъф със странична защита за Huawei Mate 30 Pro, предпазващ го от удари и надрасквания.", OldPrice = 23.99m, CurrentPrice = 18.99m, CaseMaterialId = 2, CaseTypeId = 4, ProtectionLevelId = 2, TotalVotes = 55, Score = 220, Quantity = 256 },
                new Case { Id = 55, CategoryId = 2, BrandId = 5, ProductURL = "nokia_5_4_case.png", Name = "Удароустойчив калъф за Nokia 5.4", Description = "Калъф с удароустойчиви материали за Nokia 5.4, предпазващ го от счупване при падане.", OldPrice = 19.99m, CurrentPrice = 15.99m, CaseMaterialId = 3, CaseTypeId = 7, ProtectionLevelId = 3, TotalVotes = 50, Score = 250, Quantity = 64 },
                new Case { Id = 56, CategoryId = 2, BrandId = 4, ProductURL = "samsung_galaxy_note_20_case.png", Name = "Луксозен калъф за Samsung Galaxy Note 20", Description = "Елегантен калъф за Samsung Galaxy Note 20, изработен от висококачествени материали и със стилен дизайн.", OldPrice = 28.99m, CurrentPrice = 22.99m, CaseMaterialId = 1, CaseTypeId = 1, ProtectionLevelId = 3, TotalVotes = 65, Score = 260, Quantity = 128 }
            );

            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, DiscountCode = "BANGO", DiscountPercentage = 99, ProductId = 1, StartDate = DateTime.ParseExact("05.07.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("25.07.2042", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 2, DiscountCode = "WXYZ123", DiscountPercentage = 49, ProductId = 27, StartDate = DateTime.ParseExact("03.09.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("27.09.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 3, DiscountCode = "MNBVCXZ", DiscountPercentage = 26, ProductId = 13, StartDate = DateTime.ParseExact("07.11.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("22.11.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 4, DiscountCode = "ASDFQWE", DiscountPercentage = 68, ProductId = 34, StartDate = DateTime.ParseExact("02.12.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("28.12.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 5, DiscountCode = "POIUYTR", DiscountPercentage = 12, ProductId = 25, StartDate = DateTime.ParseExact("06.02.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("26.02.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 6, DiscountCode = "QWERTYU", DiscountPercentage = 45, ProductId = 4, StartDate = DateTime.ParseExact("04.04.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("24.04.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 7, DiscountCode = "FGHJKLP", DiscountPercentage = 52, ProductId = 17, StartDate = DateTime.ParseExact("08.06.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("23.06.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 8, DiscountCode = "ZXCVBNM", DiscountPercentage = 18, ProductId = 8, StartDate = DateTime.ParseExact("01.08.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("30.08.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 9, DiscountCode = "UIOPGFD", DiscountPercentage = 34, ProductId = 29, StartDate = DateTime.ParseExact("03.10.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("28.10.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 10, DiscountCode = "KJHGFDS", DiscountPercentage = 63, ProductId = 10, StartDate = DateTime.ParseExact("07.12.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("22.12.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 11, DiscountCode = "MNBVCXZ", DiscountPercentage = 77, ProductId = 19, StartDate = DateTime.ParseExact("02.02.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("28.02.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 12, DiscountCode = "LKJHGFDS", DiscountPercentage = 26, ProductId = 12, StartDate = DateTime.ParseExact("06.04.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("26.04.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 13, DiscountCode = "QAZWSX", DiscountPercentage = 33, ProductId = 2, StartDate = DateTime.ParseExact("10.02.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("20.06.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 14, DiscountCode = "EDCRFV", DiscountPercentage = 55, ProductId = 14, StartDate = DateTime.ParseExact("14.03.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("24.08.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 15, DiscountCode = "TGBYHN", DiscountPercentage = 22, ProductId = 15, StartDate = DateTime.ParseExact("18.04.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("28.10.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 16, DiscountCode = "YHNJUM", DiscountPercentage = 71, ProductId = 6, StartDate = DateTime.ParseExact("22.05.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("02.01.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 17, DiscountCode = "IKJUHY", DiscountPercentage = 45, ProductId = 19, StartDate = DateTime.ParseExact("02.06.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("12.02.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 18, DiscountCode = "LOIKUJ", DiscountPercentage = 83, ProductId = 18, StartDate = DateTime.ParseExact("08.07.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("18.04.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 19, DiscountCode = "POKJNH", DiscountPercentage = 29, ProductId = 9, StartDate = DateTime.ParseExact("12.08.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("22.06.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 20, DiscountCode = "WSXEDC", DiscountPercentage = 61, ProductId = 20, StartDate = DateTime.ParseExact("16.09.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("26.08.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 21, DiscountCode = "RFVTGB", DiscountPercentage = 37, ProductId = 21, StartDate = DateTime.ParseExact("20.10.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("30.10.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 22, DiscountCode = "YHNUJM", DiscountPercentage = 76, ProductId = 22, StartDate = DateTime.ParseExact("24.11.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("03.01.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 23, DiscountCode = "IKMNHJ", DiscountPercentage = 41, ProductId = 3, StartDate = DateTime.ParseExact("28.12.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("09.03.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 24, DiscountCode = "UJNMKI", DiscountPercentage = 88, ProductId = 24, StartDate = DateTime.ParseExact("04.01.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("14.04.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 25, DiscountCode = "NHYUJM", DiscountPercentage = 53, ProductId = 25, StartDate = DateTime.ParseExact("08.02.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("18.06.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 26, DiscountCode = "BHJUYG", DiscountPercentage = 19, ProductId = 26, StartDate = DateTime.ParseExact("12.03.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("22.08.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 27, DiscountCode = "YBGTVF", DiscountPercentage = 32, ProductId = 7, StartDate = DateTime.ParseExact("16.04.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("26.10.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 28, DiscountCode = "NJKIMH", DiscountPercentage = 68, ProductId = 11, StartDate = DateTime.ParseExact("20.05.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("30.01.2027", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 29, DiscountCode = "THYUJM", DiscountPercentage = 47, ProductId = 17, StartDate = DateTime.ParseExact("24.06.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("03.04.2027", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 30, DiscountCode = "OLKIUJ", DiscountPercentage = 75, ProductId = 13, StartDate = DateTime.ParseExact("28.07.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("08.07.2027", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 31, DiscountCode = "POIUYT", DiscountPercentage = 22, ProductId = 31, StartDate = DateTime.ParseExact("01.08.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("11.10.2027", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 32, DiscountCode = "RFVGBH", DiscountPercentage = 88, ProductId = 32, StartDate = DateTime.ParseExact("05.09.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("15.01.2028", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 33, DiscountCode = "QAZWSX", DiscountPercentage = 41, ProductId = 33, StartDate = DateTime.ParseExact("09.10.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("19.03.2028", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 34, DiscountCode = "EDCVFR", DiscountPercentage = 59, ProductId = 34, StartDate = DateTime.ParseExact("13.11.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("23.05.2028", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 35, DiscountCode = "OKMUNY", DiscountPercentage = 16, ProductId = 5, StartDate = DateTime.ParseExact("17.12.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("27.09.2028", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 36, DiscountCode = "PLKIJU", DiscountPercentage = 73, ProductId = 36, StartDate = DateTime.ParseExact("21.01.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("01.12.2028", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 37, DiscountCode = "BVCFRT", DiscountPercentage = 28, ProductId = 37, StartDate = DateTime.ParseExact("25.02.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("05.04.2029", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 38, DiscountCode = "IKUJHY", DiscountPercentage = 64, ProductId = 38, StartDate = DateTime.ParseExact("01.03.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("11.06.2029", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 39, DiscountCode = "QAZXSW", DiscountPercentage = 37, ProductId = 39, StartDate = DateTime.ParseExact("05.04.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("15.08.2029", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 40, DiscountCode = "GBHNYU", DiscountPercentage = 52, ProductId = 40, StartDate = DateTime.ParseExact("09.05.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("19.10.2029", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 41, DiscountCode = "RFVGTB", DiscountPercentage = 49, ProductId = 41, StartDate = DateTime.ParseExact("13.06.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("23.12.2029", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
                new Coupon { Id = 42, DiscountCode = "LGBTV", DiscountPercentage = 61, ProductId = 42, StartDate = DateTime.ParseExact("17.07.2026", "dd.MM.yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("27.02.2030", "dd.MM.yyyy", CultureInfo.InvariantCulture) });

            modelBuilder.Entity<ImageExtension>().HasData(
                new ImageExtension { Id = 1, Extension = "png" },
                new ImageExtension { Id = 2, Extension = "jpg" },
                new ImageExtension { Id = 3, Extension = "jpeg" },
                new ImageExtension { Id = 4, Extension = "bmp" },
                new ImageExtension { Id = 5, Extension = "webp" },
                new ImageExtension { Id = 6, Extension = "tif" },
                new ImageExtension { Id = 7, Extension = "tiff" });
        }
    }
}
