using System.Collections.Generic;
using System.Linq;
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
            foreach(var item in cartItems)
            {
                booksInCart.Add(_bookService.GetCartBookById(item));
            }

            return booksInCart;
        }
        
        public void ChangeQuantity(int[] qtys, string userId)
        {
            var cartItems = _cartRepo.GetCart(userId);
            for(int i = 0; i < qtys.Length; i++)
            {
                cartItems[i].Quantity = qtys[i];
            }
            _cartRepo.ChangeQuantity(cartItems);
        }
        public void RemoveBook(CartItem item)
        {
            _cartRepo.RemoveBook(item);
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