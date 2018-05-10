using System.Collections.Generic;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;
using System.Linq;

namespace BookCave.Services
{
    public class SearchService
    {
        private BookRepo _bookRepo;

        public SearchService()
        {
            _bookRepo = new BookRepo();
        }
        
        public List<BookViewModel> GetSearchResults(SearchInputModel search)
        {
            return _bookRepo.GetSearchResults(search);
        }

        public List<BookViewModel> SortByNameAscending(List<BookViewModel> results)
        {
            return results.OrderBy(r => r.Title).ToList();
        }
    }
}