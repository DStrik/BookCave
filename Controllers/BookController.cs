using System;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Top10()
        {
            return View();
        }
        public IActionResult NewReleases()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}