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

        public List<BookCartViewModel> GetCart(string userId)
        {            
            var booksInCart = new List<BookCartViewModel>();
            var _bookService = new BookService();
            var cartItems = _cartRepo.GetCart(userId);
            foreach(var id in cartItems)
            {
                booksInCart.Add(_bookService.GetCartBookById(id));
            }

            return booksInCart;
        }
        
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