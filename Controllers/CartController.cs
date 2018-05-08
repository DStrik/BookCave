using System.Threading.Tasks;
using BookCave.Data.EntityModels;
using BookCave.Models;
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
        public void ChangeQuantity(int BookId)
        {

        }
        public void RemoveBook(int BookId)
        {

        }
        public void ClearCart()
        {
            
        }
        public void AddToCart(int bookId, ApplicationUser user)
        {
                var item = new CartItem {
                BookId = bookId,
                UserId = user.Id

                };
            _cartService.AddToCart(item);
        }

    }
}