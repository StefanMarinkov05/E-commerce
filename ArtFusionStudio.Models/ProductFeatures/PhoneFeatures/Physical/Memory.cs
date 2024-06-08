using ArtFusionStudio.Utility;
using System.ComponentModel.DataAnnotations;

namespace ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.Physical
{
    public class Memory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [Range(0, 32, ErrorMessage = ErrorMessages.NOT_NEGATIVE_NUM + " 32GB.")]
        public int RAM { get; set; }
    }
}
