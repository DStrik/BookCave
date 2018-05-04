using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;

namespace BookCave.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageTitle = "Dashboard home";
            return View();
        }

        public IActionResult AddBook() 
        {
            return View();
        }

        public IActionResult ViewBooks() 
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

        public IActionResult AddEmployee() 
        {
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

        public IActionResult Login()
        {
            ViewBag.PageTitle = "Login to site management";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}