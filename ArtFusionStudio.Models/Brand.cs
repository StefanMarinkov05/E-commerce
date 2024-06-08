using ArtFusionStudio.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ArtFusionStudio.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [StringLength(32, MinimumLength = 2, ErrorMessage = ErrorMessages.OUT_OF_RANGE + " 2 и 32.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        public required string PathD { get; set; }

        
    }
}
