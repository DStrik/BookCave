using System;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

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
        public IActionResult NewReleases()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var book = _bookService.GetBookDetails(id);
            return View(book);
        }

        public async Task<string> GetUserNameById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            
            var retVal = user.FirstName + " " + user.LastName;

            return retVal;      
        }
    }
}