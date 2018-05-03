using System.Collections.Generic;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
namespace BookCave.Repositories
{
    public class BookRepo
    {
        public void WriteBook(BookInputModel book)
        {
            
        }

        public List<BookViewModel> GetAllBooks()
        {
            return new List<BookViewModel>();
        }

        public void UpdateBook(BookInputModel book)
        {

        }

        public void DeleteBook(int BookId)
        {
            
        }

        public List<BookViewModel> GetTop10()
        {
            return new List<BookViewModel>();
        }

        public List<BookViewModel> GetNewReleases()
        {
            return new List<BookViewModel>();
        }

        public BookDetailViewModel GetBookDetails(int BookId)
        {
            return new BookDetailViewModel();
        }

        public List<BookViewModel> Results(BookInputModel Search)
        {
            return new List<BookViewModel>();
        }

        public List<BookViewModel> GetBooksInCart(List<int> Ids)
        {
            return new List<BookViewModel>();
        }
    }
}