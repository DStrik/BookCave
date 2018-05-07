using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BookCave.Models;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private BookService _bookService;
        private UserService _userService;
        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _bookService = new BookService();
            _userService = new UserService();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginInputModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(UserSignUpInputModel model)
        {
            if(!ModelState.IsValid) 
            {
                return View();
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email};

            var result = await _userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult AccountInformation()
        {   
            return View();
        }

        public IActionResult ChangeImage(string Img)
        {
            return View();
        }

        [HttpGet]
        public async Task<ShippingBillingViewModel> GetShippingBillingInformation ()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if(user == null)
            {
                return null;
            }

            ShippingBillingViewModel shipBill = _userService.GetShippingBillingInfo(user.Id);
            if(shipBill == null)
            {
                return null;
            }

            return shipBill;
        }

        public async Task<IActionResult> ChangeShippingInformation (ShippingInputModel ShipBillInfo)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            return Ok();
        }

        [HttpGet]
        public void ChangeBillingInformation(BillingInputModel BillInfo)
        {
            
        }

        public void ChangePaymenrInformation(PaymentInputModel PaymentInfo)
        {

        }

        public IActionResult FavoriteBook()
        {
            var data = _bookService.GetBookById(13);

            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserChangePasswordInputModel data)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if(data.NewPassword == data.ConfirmPassword)
            {
                var result = await _userManager.ChangePasswordAsync(user, data.OldPassword, data.NewPassword);
                if(result.Succeeded)
                {
                    return Ok();
                }  
            }

            return BadRequest();
        }

        public IActionResult OrderHistory()
        {
            return View();
        }

        public IActionResult Wishlist()
        {
            return View();
        }

        public void AddToWishlist(int BookId)
        {

        }

        public void RemoveFromWishlist(int BookId)
        {

        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}