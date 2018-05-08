using System.Collections.Generic;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

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
    }
}