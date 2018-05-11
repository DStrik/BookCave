using System.Collections.Generic;
using System.Threading.Tasks;
using BookCave.Models;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers

{
    public class CheckOutController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private CheckOutService _checkOutService;
        
        public CheckOutController(UserManager<ApplicationUser> userManger)
        {
            _userManager = userManger;
            _checkOutService = new CheckOutService();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var info = _checkOutService.GetShippingBillingViewModel(user.Id);
            if(info == null)
            {
                return View();
            }

            return View(info);
        }
        
        [HttpPost]
        public IActionResult Index(int id)
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
        [HttpGet]
        public IActionResult GetCart()
        {
            var user = _userManager.GetUserId(HttpContext.User);
            List<BookCartViewModel> cart = _checkOutService.GetCart(user);
            return Json(cart);
        }

        [HttpGet]
        public IActionResult Verify(CheckOutInputModel info)
        {
            if(ModelState.IsValid)
            {
                return Ok(info);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Pay(CheckOutInputModel info)
        {
            if(ModelState.IsValid)
            {
                var user = _userManager.GetUserId(HttpContext.User);
                _checkOutService.AddOrder(info, user);
                return Ok();
            }
            return BadRequest();
        }
    }
}