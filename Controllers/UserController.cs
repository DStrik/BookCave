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
using System.Linq;

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
                return BadRequest();
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if(result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
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
                return BadRequest();
            }

            if(!model.TermsAndConditions)
            {
                return BadRequest();
            }

            var user = new ApplicationUser {UserName = model.Email, Email = model.Email};

            var result = await _userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");

                await _userManager.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                await _signInManager.SignInAsync(user, false);

                _userService.addDefaultImage(user.Id);
                var updateResult = await _userManager.UpdateAsync(user);
                if(updateResult.Succeeded)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> AccountInformation()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if(user == null)
            {
                return View(); // Should go to error page here
            }

            var model = _userService.GetUserImage(user.Id);

            if(model == null)
            {
                return View(); // Should go to error page here
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

            var success = await _userService.ChangeImage(input, user.Id);

            if(!success)
            {
                return RedirectToAction("AccountInformation", "User"); // should go to error page
            }

            return RedirectToAction("AccountInformation", "User");
        }

        public IActionResult ChangeImage(string Img)
        {
            return View();
        }

        public async Task<IActionResult> FavoriteBook()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var data = _bookService.GetBookDetails(user.FavBookId);

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
            var userId = _userManager.GetUserId(HttpContext.User);
            var orders = _userService.GetOrderHistory(userId);

            return View(orders);
        }
        public IActionResult OrderDetails(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var order = _userService.GetOrderDetails(id, userId);

            return Json(order);

        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

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

        public async Task<IActionResult> ChangeFirstLastName(UserChangeName Name)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            var result = await _userManager.ReplaceClaimAsync(user, ((ClaimsIdentity) User.Identity).Claims.FirstOrDefault(c => c.Type == "Name"), new Claim("Name", $"{Name.FirstName} {Name.LastName}"));

            if(result.Succeeded)
            {
                user.FirstName = Name.FirstName;
                user.LastName = Name.LastName;
                var updateResult = await _userManager.UpdateAsync(user);
                if(updateResult.Succeeded)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        public async Task<IActionResult> SetFavoriteBookId(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if(user == null)
            {
                return BadRequest();
            }

            user.FavBookId = id;
            var result = await _userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult TermsAndConditions()
        {
            return View();
        }
    }

}