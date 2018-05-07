using System.Collections.Generic;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class CartService
    {

        private CartRepo _cartRepo;
        public CartService()
        {
            _cartRepo = new CartRepo();
        }

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
        public void AddToCart(CartItem item)
        {
            _cartRepo.AddToCart(item);
        }
    }
}