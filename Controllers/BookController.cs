using System;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using BookCave.Models.InputModels;
using System.Collections.Generic;
using BookCave.Models.ViewModels;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;
        private readonly UserManager<ApplicationUser> _userManager;
        
        private UserService _userService;

        public BookController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _bookService = new BookService();
            _userService = new UserService();
        }

        public IActionResult Top10()
        {
            List<BookViewModel> books = _bookService.GetTop10();
            if (books.Count < 10){
                return View("Top10NotAvailable");
            }
            return View(books);
        }

        public async Task<IActionResult> AddReview(ReviewInputModel review)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var reviewer = user.FirstName + " "  + user.LastName;
                _bookService.AddReview(review, user.Id, reviewer);
                return Ok();
            }
            return BadRequest();
        }
        public async Task<IActionResult> Details(int id)
        {
            var book = _bookService.GetBookDetails(id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null) 
            {
                book.UserImage = null;
            } 
            else 
            {
                var userView = _userService.GetUserImage(user.Id);
                book.UserImage = userView.Image;
            }
            return View(book);
        }

        public async Task<IActionResult> SetFavoriteBook(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if(user == null)
            {
                return BadRequest();
            }

            user.FavBookId = id;
            var result = await _userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();

        }
    }
}