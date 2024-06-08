using ArtFusionStudio.Utility;
using System.ComponentModel.DataAnnotations;

namespace ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.Physical
{
    public class StorageCapacity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [Range(0,2048, ErrorMessage = ErrorMessages.NOT_NEGATIVE_NUM + " 2048.")]
        public required decimal CapacityGB { get; set; }
    }
}
