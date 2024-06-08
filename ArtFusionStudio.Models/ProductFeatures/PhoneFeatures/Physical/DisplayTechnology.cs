using ArtFusionStudio.Utility;
using System.ComponentModel.DataAnnotations;

namespace ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.Physical
{
    public class DisplayTechnology
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [StringLength(32, MinimumLength = 2, ErrorMessage = ErrorMessages.OUT_OF_RANGE + " 2 и 32.")]
        public required string Name { get; set; }
    }
}
