using System;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using BookCave.Models.InputModels;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _bookService = new BookService();
        }

        public IActionResult Top10()
        {
            return View();
        }
        public async Task<IActionResult> AddReviewAsync(ReviewInputModel review)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var reviewer = user.FirstName + user.LastName;
            _bookService.AddReview(review, reviewer);
            return Ok();
        }
        public IActionResult Details(int id)
        {
            var book = _bookService.GetBookDetails(id);
            return View(book);
        }
    }
}