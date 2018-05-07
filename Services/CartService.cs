using System.Collections.Generic;
using BookCave.Models.ViewModels;

namespace BookCave.Services
{
    public class CartService
    {
        /*public List<BookViewModel> GetCart(int UserId)
        {
            //Ehv kóði sem sækir lista af bookId úr cookies/cache köllum hann List<int> cartItem
            
            var booksInCart = new List<BookViewModel>();
            var _bookService = new BookService();
            foreach(var id in cartItems)
            {
                booksInCart.Add(_bookService.GetBookById(id));
            }

            return booksInCart;
        }
        */
        public void ChangeQuantity(int BookId, int UserId)
        {

        }
        public void RemoveBook(int BookId, int UserId)
        {

        }
        public void ClearCart(int UserId)
        {
            
        }
    }
}