using System;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;
        public BookController()
        {
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
    }
}