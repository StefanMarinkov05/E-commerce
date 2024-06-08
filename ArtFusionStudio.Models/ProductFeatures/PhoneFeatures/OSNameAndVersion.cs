using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArtFusionStudio.Utility;

namespace ArtFusionStudio.Models.ProductFeatures.PhoneFeatures
{
    public class OSNameAndVersion
    {
        [Key]
        public int Id { get; set; }

        public int OSNameId { get; set; }
        [ForeignKey("OSNameId")]
        public OperatingSystem? OperatingSystem { get; set; }

        public int OSVersionId { get; set; }
        [ForeignKey("OSVersionId")]
        public OperatingSystemVersion? OperatingSystemVersion { get; set; }

        public string OSNamePlusVersion
        {
            get
            {
                return $"{OperatingSystem?.OSName} {OperatingSystemVersion?.OSVersion.FormatDecimal()}";
            }
        }
    }
}
