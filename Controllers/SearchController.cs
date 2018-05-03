using BookCave.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Results(BookInputModel Srch)
        {
            return View();
        }
    }
}