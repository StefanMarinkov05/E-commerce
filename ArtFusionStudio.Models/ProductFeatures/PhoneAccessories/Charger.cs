using ArtFusionStudio.Utility;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ArtFusionStudio.Models.ProductFeatures.PhoneAccessories
{
    public class Charger : Product
    {
        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [Range(0, 24, ErrorMessage = ErrorMessages.NOT_NEGATIVE_NUM + " 24V.")]
        public int OutputVoltage { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [Range(0, 32, ErrorMessage = ErrorMessages.NOT_NEGATIVE_NUM + " 24A.")]
        public int OutputCurrent { get; set; }

        [AllowNull]
        public bool FastChargingSupported { get; set; }
    }
}
