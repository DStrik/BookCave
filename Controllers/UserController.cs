using BookCave.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Login(string Name, string Password)
        {
            return View();
        }
        public IActionResult SignUp(UserInputModel User)
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
        public void ChangeShippingBillingInformation(ShippingBillingInputModel ShipBillInfo)
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