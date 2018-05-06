using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Models.InputModels;
using Microsoft.AspNetCore.Identity;
using BookCave.Data;
using BookCave.Services;

namespace BookCave.Controllers
{
    public class ManageController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManageController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewBag.PageTitle = "Dashboard home";
            return View();
        }

        public IActionResult AddBook() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult RefreshAuthors()
        {
            BookService b = new BookService();
            var allAuthors = b.GetAllAuthors();
            return Json(allAuthors);
        }

        public IActionResult RefreshGenres()
        {
            return View();
        }

        public IActionResult RefreshPublishers()
        {
            return View();
        }

        public IActionResult ViewBooks() 
        { 
            return View();
        }

        public IActionResult AddAuthor() 
        {
            return View();
        }

        public IActionResult AddPublisher() 
        {
            return View();
        }

        public IActionResult AddGenre()
        {
            return View();
        }

        public IActionResult Orders() 
        {
            return View();
        }

        public IActionResult Stock() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEmployee() 
        {
            return View();
        }     

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(EmployeeRegisterInputModel model) 
        {
            if (!ModelState.IsValid) { return View(); }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded) 
            {
                // New employee successfully created and admin gets prompted
                return RedirectToAction("Index", "Manage");
            }

            return View();
        }                   

        public IActionResult ManageEmployees() 
        {
            return View();
        }



        public IActionResult ChangePassword() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.PageTitle = "Login to site management";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(EmployeeLoginInputModel model) 
        {
            if (!ModelState.IsValid) { return View(); }

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Manager");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Manager");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}