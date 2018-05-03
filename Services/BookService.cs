using System.Collections.Generic;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;

namespace BookCave.Services
{
    public class BookService
    {
        public List<BookViewModel> GetTop10()
        {
            return null;
        }
        public List<BookViewModel> GetNewReleases()
        {
            return null;
        }
        public BookDetailViewModel GetBookDetails(int BookId)
        {
            //TO DO!!!
            return null;
        }
        public BookInputModel GetBookInputModel()
        {
            return null;
        }
        public void ModifyBook(BookInputModel book)
        {

        }
        public void WriteBook(BookInputModel book)
        {

        }
        List<BookViewModel> GetAllBooks()
        {
            return null;
        }

    }
}