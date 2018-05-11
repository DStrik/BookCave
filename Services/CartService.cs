using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class CartService
    {

        private CartRepo _cartRepo;
        private BookService _bookService;
        public CartService()
        {
            _cartRepo = new CartRepo();
            _bookService = new BookService();
        }

        public List<BookCartViewModel> GetCart(string userId)
        {            
            var booksInCart = new List<BookCartViewModel>();
            
            var cartItems = _cartRepo.GetCart(userId);
            foreach(var item in cartItems)
            {
                var book = _bookService.GetCartBookById(item);
                if(book != null)
                {
                    booksInCart.Add(book);
                }
            }

            return booksInCart;
        }
        
        public void ChangeQuantity(int[] qtys, int[] cartItemIds, string userId)
        {
            var cartItems = new List<CartItem>();
            for(int i = 0; i < cartItemIds.Length; i++)
            {
                var item = _cartRepo.GetCartItem(cartItemIds[i], userId);
                item.Quantity = qtys[i];
                cartItems.Add(item);
            }
            _cartRepo.ChangeQuantities(cartItems);
        }

        public void RemoveItem(int cartItemId, string userId)
        {
            var item = _cartRepo.GetCartItem(cartItemId, userId);
            if(item != null)
            {
                _cartRepo.RemoveItem(item);
            }
            
        }
        public void ClearCart(string userId)
        {
            _cartRepo.ClearCart(userId);
        }
        public void AddToCart(string userId, int bookId)
        {   
            var contains = _cartRepo.Contains(userId, bookId);
            if(contains)
            {
                var item = _cartRepo.GetCartItemByIds(userId, bookId);
                item.Quantity += 1;
                _cartRepo.ChangeQuantity(item);
            }
            else
            {
                CartItem item = new CartItem
                {
                    UserId  = userId,
                    BookId = bookId,
                    Quantity = 1
                };
                _cartRepo.AddToCart(item);
            }
        }

        public void RemoveBookFromCarts(int bookId)
        {
            _cartRepo.RemoveBookFromCarts(bookId);
        }
    }
}