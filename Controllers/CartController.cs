using System.Collections.Generic;
using System.Threading.Tasks;
using BookCave.Data.EntityModels;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    [Authorize]
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
        public void ChangeQuantity(int[] qtys, int[] cartItemIds)
        {
            _cartService.ChangeQuantity(qtys, cartItemIds);

        }
        [HttpPost]
        public void RemoveItem(int cartItemId)
        {
            _cartService.RemoveItem(cartItemId);
        }
        /* 
        public void ClearCart(int[] cartItems)
        {
            _cartService.ClearCart(cartItems);
        }
*/
        public IActionResult AddToCart(int id)
        {
            var user = _userManager.GetUserId(HttpContext.User);
            _cartService.AddToCart(user, id);

            return Ok();
        }
    }
}