using System.Net;
using BookCave.Models;
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
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User); 
            var cartItems = _cartService.GetCart(userId);
            
            return View(cartItems);
        }
        [HttpPost]
        public void ChangeQuantity(int[] qtys, int[] cartItemIds)
        { 
            var userId = _userManager.GetUserId(HttpContext.User); 
            _cartService.ChangeQuantity(qtys, cartItemIds, userId);

        }
        [HttpPost]
        public void RemoveItem(int cartItemId)
        {   
            var userId = _userManager.GetUserId(HttpContext.User); 
            _cartService.RemoveItem(cartItemId, userId);
        }
        
        public void ClearCart()
        {   var userId = _userManager.GetUserId(HttpContext.User);            
            _cartService.ClearCart(userId);
        }

        [AllowAnonymous]
        public IActionResult AddToCart(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if(userId != null)
            {
                _cartService.AddToCart(userId, id);
                return Ok();
            } 
            else
            {
                 Response.StatusCode = (int) HttpStatusCode.BadRequest;
                 return Json("Login");
            }
        }
    }
}