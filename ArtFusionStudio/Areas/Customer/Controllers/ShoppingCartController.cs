using ArtFusionStudio.Areas.Admin.Controllers;
using ArtFusionStudio.DataAccess.Data;
using ArtFusionStudio.Models;
using ArtFusionStudio.Models.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ArtFusionStudio.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ShoppingCartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult CartView()
        {
            DisplayLayoutController.AcceessAllTables(this, _context);

            // Retrieve the current user's ID
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Get the shopping cart for the current user
            var shoppingCart = _context.ShoppingCarts
                .Include(cart => cart.Items)
                .ThenInclude(item => item.Product)
                .FirstOrDefault(cart => cart.UserId == userId);

            // Pass the shopping cart items to the view
            return View(shoppingCart.Items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var shoppingCart = await _context.ShoppingCarts
                .Include(sc => sc.Items)
                .FirstOrDefaultAsync(sc => sc.UserId == user.Id);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart { UserId = user.Id };
                _context.ShoppingCarts.Add(shoppingCart);
            }

            var cartItem = shoppingCart.Items.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                shoppingCart.Items.Add(new ShoppingCartItem
                {
                    ProductId = productId,
                    Quantity = 1
                });
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Products"); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(int itemId)
        {
            var cartItem = await _context.ShoppingCartItems.FindAsync(itemId);
            if (cartItem == null)
            {
                return NotFound();
            }

            _context.ShoppingCartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(CartView));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ClearCart()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var shoppingCart = await _context.ShoppingCarts
                .Include(cart => cart.Items)
                .FirstOrDefaultAsync(cart => cart.UserId == user.Id);

            if (shoppingCart != null)
            {
                _context.ShoppingCartItems.RemoveRange(shoppingCart.Items);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Products");
        }

    }
}

