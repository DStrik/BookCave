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
using System.Security.Claims;

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
            if (ModelState.IsValid)
            {
                _bookService.AddBook(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {

            var allAuthors = _bookService.GetAllAuthors();
            return Json(allAuthors);
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult ViewBooks()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ModifyBookById(int id)
        {
            var book = _bookService.GetBookModifyModel(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult ModifyBookById(BookModifyInputModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.ModifyBook(model);
                return Ok();
            }
            return BadRequest();
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
            if (ModelState.IsValid)
            {
                _bookService.AddAuthor(model);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult AddPublisher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPublisher(PublisherInputModel model)
        {
            if (ModelState.IsValid)
            {
            _bookService.AddPublisher(model);
            return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGenre(GenreInputModel model)
        {
            if(ModelState.IsValid)
            {
                _bookService.AddGenre(model);
                return Ok();
            }
            return BadRequest();
            
        }

        [HttpPost]
        public void RemoveBookById(int id)
        {
            _bookService.RemoveBookById(id);
        }

        [HttpGet]
        public IActionResult Orders()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Stock()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateStock()
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
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.UserType);
                //Það þarf að laga AddEmployee.cshtml
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));
                return RedirectToAction("AddEmployee");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ViewEmployeesList()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}