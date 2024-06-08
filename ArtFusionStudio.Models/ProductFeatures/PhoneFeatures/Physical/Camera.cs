using ArtFusionStudio.Utility;
using System.ComponentModel.DataAnnotations;

namespace ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.Physical
{
    public class Camera
    {
        [Key]
        public int Id { get; set; }

        
        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [Range(0, 16, ErrorMessage = ErrorMessages.NOT_NEGATIVE_NUM + " 16.")]
        public required byte CameraCount { get; set; }
    }
}
