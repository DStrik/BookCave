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
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public CartController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _cartService = new CartService();
            _bookService = new BookService();
        }
        public IActionResult Index()
        {
            var user = GetCurrentUserAsync();
            var list = _bookService.GetBookList();
            return View(list);
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
        public void AddToCart(int bookId)
        {
            var user = GetCurrentUserAsync();
            var userId = user?.Id;
            if(userId == null)
            {

            }
            else
            {
                var item = new CartItem {
                BookId = bookId,
                UserId = userId

            };
           // _cartService.AddToCart(item);
            }
        }

    }
}