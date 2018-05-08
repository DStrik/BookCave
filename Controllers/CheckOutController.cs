using System.Threading.Tasks;
using BookCave.Models;
using BookCave.Models.InputModels;
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
    }
}