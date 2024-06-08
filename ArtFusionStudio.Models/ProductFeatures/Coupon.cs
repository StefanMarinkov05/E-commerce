using ArtFusionStudio.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtFusionStudio.Models.ProductFeatures
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 2, ErrorMessage = ErrorMessages.OUT_OF_RANGE + " 2 и 32.")]
        public required string DiscountCode { get; set; }

        [Required]
        [Range(0.0, 99.9, ErrorMessage = ErrorMessages.NOT_NEGATIVE_NUM + " 100.")]
        public required decimal DiscountPercentage { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd .MM. yyyy}", ApplyFormatInEditMode = true)]
        public required DateTime StartDate { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd .MM. yyyy}", ApplyFormatInEditMode = true)]
        [EndDateValidation(ErrorMessage = ErrorMessages.INVALID_END_DATE)]
        public required DateTime EndDate { get; set; }
    }

    public class EndDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var endDate = (DateTime)value;
            var coupon = (Coupon)validationContext.ObjectInstance;

            if (endDate.Date < coupon.StartDate.Date)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
