using ArtFusionStudio.Utility;
using System.ComponentModel.DataAnnotations;

namespace ArtFusionStudio.Models.ProductFeatures.PhoneFeatures
{
    public class OperatingSystemVersion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = ErrorMessages.INVALID_DECIMAL)]
        [Range(0, 99, ErrorMessage = ErrorMessages.OUT_OF_RANGE_NUM + " и по-малко от 99.")]
        public required decimal OSVersion { get; set; }
    }
}
