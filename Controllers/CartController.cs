using System.Collections.Generic;
using System.Threading.Tasks;
using BookCave.Data.EntityModels;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private CartService _cartService;
        private BookService _bookService;

        public CartController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _cartService = new CartService();
            _bookService = new BookService();
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var cartItems = _cartService.GetCart(user.Id);
            
            return View(cartItems);
        }
        [HttpPost]
        public async void ChangeQuantity(int[] qtys, int[] cartItemIds)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            _cartService.ChangeQuantity(qtys, cartItemIds);

        }
        public void RemoveItem(int cartItemId)
        {
            _cartService.RemoveItem(cartItemId);
        }
        public void ClearCart()
        {
            
        }
        public void AddToCart(ApplicationUser user, int bookId)
        {
                var item = new CartItem {
                BookId = bookId,
                UserId = user.Id,
                Quantity = 1

                };
            _cartService.AddToCart(item);
        }

    }
}