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
        public async void ChangeQuantity(int[] qtys)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            _cartService.ChangeQuantity(qtys, user.Id);

        }
        public void RemoveBook(int BookId, ApplicationUser user)
        {
            var book = _bookService.GetBookById(BookId);
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