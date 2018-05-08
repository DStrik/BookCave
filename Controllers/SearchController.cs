using BookCave.Models.InputModels;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class SearchController : Controller
    {
        private SearchService _searchService;
        private BookService _bookService;

        public SearchController()
        {
            _searchService = new SearchService();
            _bookService = new BookService();
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Results(SearchInputModel search)
        {
            var results = _searchService.GetSearchResults(search);
            var test = results;
            test.Add(results[0]);
            test.Add(results[1]);
            test.Add(results[1]);
            test.Add(results[0]);
            test.Add(results[1]);
            test.Add(results[0]);
            test.Add(results[0]);
            test.Add(results[1]);
            test.Add(results[1]);
            test.Add(results[1]);
            
            return View(test);
        }
    
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
    }
}