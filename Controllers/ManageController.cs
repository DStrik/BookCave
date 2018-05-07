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
using BookCave.Data.EntityModels;

namespace BookCave.Controllers
{
    public class ManageController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        BookService _bookService = new BookService();

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

        [HttpGet]
        public IActionResult AddBook() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(BookInputModel model) 
        {
            _bookService.AddBook(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            
            var allAuthors = _bookService.GetAllAuthors();
            return Json(allAuthors);
        }

        public IActionResult GetAllGenres()
        {
            var allGenres = _bookService.GetAllGenres();
            return Json(allGenres);
        }

        public IActionResult GetAllPublishers()
        {
            var allPublishers = _bookService.GetAllPublishers();
            return Json(allPublishers);
        }

        public IActionResult ViewBooks() 
        { 
            return View();
        }

        [HttpGet]
        public IActionResult GetBookList()
        {
            var allBooks = _bookService.GetBookList();
            return Json(allBooks);
        }

        [HttpGet]
        public IActionResult AddAuthor() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorInputModel model)
        {
            _bookService.AddAuthor(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddPublisher() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPublisher(PublisherInputModel model)
        {
            _bookService.AddPublisher(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGenre(GenreInputModel model)
        {
            _bookService.AddGenre(model);
            return RedirectToAction("Index");
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
            if(!ModelState.IsValid)
            {
                return View();
            }
            
            var user = new ApplicationUser {UserName = model.Email, Email = model.Email};
            var result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.UserType);
                return RedirectToAction("AddEmployee");
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