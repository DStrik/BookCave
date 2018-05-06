using System.Security.Claims;
using System.Threading.Tasks;
using BookCave.Models;
using BookCave.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

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
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
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
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));
                await _signInManager.SignInAsync(user, false);
                await _userManager.AddToRoleAsync(user, "User");

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
        public void ChangePassword(PasswordInputModel Password)
        {

        }
        public void ChangeShippingInformation(ShippingInputModel ShipBillInfo)
        {

        }
        public void ChangeBillingInformation(BillingInputModel BillInfo)
        {
            
        }
        public void ChangePaymenrInformation(PaymentInputModel PaymentInfo)
        {

        }
        [Authorize]
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
    }
}