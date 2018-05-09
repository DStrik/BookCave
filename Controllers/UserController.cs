using System;
using System.IO;
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

                _userService.addDefaultImage(user.Id);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        private string GetDefaultProfileImage()
        {
            using (var memoryStream = new MemoryStream())
            {
                new FileInfo("wwwroot/images/default_pic.jpg").OpenRead().CopyTo(memoryStream);
                var image =  memoryStream.ToArray();
                return System.Text.Encoding.Default.GetString(image);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AccountInformation()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if(user == null)
            {
                return View();
            }

            var model = _userService.GetUserImage(user.Id);

            if(model == null)
            {
                return View();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeImage(AccountViewModel input)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("AccountInformation", "User");
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            _userService.ChangeImage(input, user.Id);

            return RedirectToAction("AccountInformation", "User");
        }

        public IActionResult ChangeImage(string Img)
        {
            return View();
        }

        public void ChangePaymenrInformation(PaymentInputModel PaymentInfo)
        {

        }

        public IActionResult FavoriteBook()
        {
            var data = _bookService.GetBookDetails(23);

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

            var result = await _userManager.ChangePasswordAsync(user, data.OldPassword, data.NewPassword);
            
            if(result.Succeeded)
            {
                return Ok();
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

            var user = await _userManager.FindByEmailAsync("danni@danni.is");
            if(user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> EditSippingBilling()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var ret = _userService.GetShippingBillingInfo(user.Id);
            if(ret == null)
            {
                return View();
            }
            return View(ret);
        }

        [HttpPost]
        public async Task<IActionResult> EditSippingBilling(ShippingBillingInputModel input)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if(user == null)
            {
                return View();
            }

            _userService.ChangeShippingBillingInfo(input, user.Id);

            return RedirectToAction("EditSippingBilling", "User");
        }
    }

}