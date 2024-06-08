using ArtFusionStudio.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace ArtFusionStudio.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [StringLength(128, MinimumLength = 2, ErrorMessage = ErrorMessages.OUT_OF_RANGE + " 2 и  128.")]
        public string Name { get; set; }

        [AllowNull]
        [StringLength(512, MinimumLength = 2, ErrorMessage = ErrorMessages.OUT_OF_RANGE + " 2 и 512.")]
        public string Description { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [StringLength(64, MinimumLength = 2, ErrorMessage = ErrorMessages.OUT_OF_RANGE + " 2 и 64.")]
        public string ProductURL { get; set; }

        [AllowNull]
        [Range(0.0, 100000.0, ErrorMessage = ErrorMessages.NOT_NEGATIVE_NUM + " 100000.")]
        public decimal OldPrice { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [Range(0.0, 100000.0, ErrorMessage = ErrorMessages.NOT_NEGATIVE_NUM + " 100000.")]
        public required decimal CurrentPrice { get; set; }
        public int CategoryId { get; set; }

        public int BrandId { get; set; }


        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [ForeignKey("BrandId")]
        public Brand? Brand { get; set; }


        [AllowNull]
        public int TotalVotes { get; set; } = 0;

        [AllowNull]
        [ScoreValidation(ErrorMessage = ErrorMessages.INVALID_SCORE)]
        public int Score { get; set; } = 0;

        public string Rating
        {
            get
            {   
                if (TotalVotes != 0) 
                {
                    return Math.Round(((decimal)Score / (decimal)TotalVotes), 2).FormatDecimal();
                }
                else 
                    return "0";
            }
        }
        public class ScoreValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var product = (Product)validationContext.ObjectInstance;

                if (product.Score < product.TotalVotes || product.Score > 5 * product.TotalVotes)
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }
        }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [Range(0, 10000, ErrorMessage = ErrorMessages.NOT_NEGATIVE_NUM + " 10000.")]
        public required int Quantity { get; set; }
    }
}
