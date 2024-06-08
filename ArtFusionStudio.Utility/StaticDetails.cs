using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtFusionStudio.Utility
{
    public static class StaticDetails
    {
        public static readonly List<string> specialOffersClasses = new List<string>() 
            { "current", "next", "previous" };

        public static string defaultImagePath = "~/images/Logo/afs-logo-phone.png";

        public static int pageSize = 7;
        //public static readonly List<byte> camerasCount = new List<byte>()
        //    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16}
        //        .OrderBy(x => x).ToList();

        //public static readonly List<string> displayTechnology = new List<string>()
        //    { "LED", "OLED", "POLED", "AMOLED", "LCD", "LTPO", "Mini LED", "Retina" }
        //        .OrderBy(x => x).ToList();

        //public static readonly List<short> MemoryGB = new List<short>()
        //    { 8, 16, 24, 32, 48, 64, 86, 128, 196, 256, 384, 420, 512, 786, 1024 }
        //        .OrderBy(x => x).ToList();

        //public static readonly List<byte> MemoryRAM = new List<byte>()
        //    { 1, 2, 3, 4, 5, 6, 7, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 32 }
        //        .OrderBy(x => x).ToList();

        //public static readonly List<string> USBType = new List<string>()
        //    { "USB-A", "USB-B", "USB-C", "Mini-USB", "Micro-USB", "Lightning"}
        //        .OrderBy(x => x).ToList();
    }
}
