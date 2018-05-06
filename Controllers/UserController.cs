using System.Threading.Tasks;
using BookCave.Models;
using BookCave.Models.InputModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManger;
        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManger = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginInputModel user)
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpInputModel model)
        {
           /* if(!ModelState.IsValid) 
            {
                return View();
            }
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email};

            var result = await _userManger.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                return View();
            }*/
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