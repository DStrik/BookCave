using BookCave.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class UserController : Controller
    {
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
        public IActionResult SignUp(UserSignUpInputModel user)
        {
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