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

            test.Add(test[0]);
            test.Add(test[1]);
            test.Add(test[0]);
            test.Add(test[1]);
            test.Add(test[0]);
            test.Add(test[2]);
            test.Add(test[0]);
            test.Add(test[3]);
            test.Add(test[0]);
            test.Add(test[0]);
            test.Add(test[1]);
            test.Add(test[1]);
            test.Add(test[1]);
            test.Add(test[0]);
            test.Add(test[2]);
            test.Add(test[3]);
            test.Add(test[2]);
            test.Add(test[2]);
            test.Add(test[0]);
            test.Add(test[0]);
            test.Add(test[0]);
            test.Add(test[1]);
            return test;

        }

        public List<BookViewModel> SortByNameAscending(List<BookViewModel> results)
        {
            return results.OrderBy(r => r.Title).ToList();
        }
    }
}