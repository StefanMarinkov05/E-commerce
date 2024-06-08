using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ArtFusionStudio.Models.Orders
{
    public class ShoppingCart
    {
        [Key] 
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? ApplicationUser { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        [AllowNull]
        public decimal? TotalPrice 
        {
            get
            {
                if (Items.Count == 0)
                    return 0;
                else
                {
                    return Items.Select(item => item.Product.CurrentPrice).Sum();
                }
            }
        }

        [AllowNull]
        public int? TotalQuantity
        {
            get => Items.Select(c => c.Quantity).Sum();
        }
    }
}
