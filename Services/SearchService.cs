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
            var test = _bookRepo.GetSearchResults(search);

            return test;

        }
    }
}