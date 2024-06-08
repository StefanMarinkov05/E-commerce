using ArtFusionStudio.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtFusionStudio.Models.Orders
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int CartId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        
        [ForeignKey("CartId")]
        public ShoppingCart? Cart { get; set; }

        [Required(ErrorMessage = ErrorMessages.NO_BLANK_SPACE)]
        [Range(0.0, 100000.0, ErrorMessage = ErrorMessages.NOT_NEGATIVE_NUM + " 100000.")]
        public int Quantity {  get; set; }

    }
}
