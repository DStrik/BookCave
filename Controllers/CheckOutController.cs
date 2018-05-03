using BookCave.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index(ShippingBillingInputModel ShippingBillign, PaymentInputModel Payment)
        {
            return View();
        }
        public IActionResult Review()
        {
            return View();
        }
        public IActionResult Transaction()
        {
            return View();
        }
    }
}