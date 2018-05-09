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
                booksInCart.Add(_bookService.GetCartBookById(item));
            }

            return booksInCart;
        }
        
        public void ChangeQuantity(int[] qtys, int[] cartItemIds)
        {
            var cartItems = new List<CartItem>();
            for(int i = 0; i < cartItemIds.Length; i++)
            {
                CartItem item = _cartRepo.GetCartItem(cartItemIds[i]);
                item.Quantity = qtys[i];
                cartItems.Add(item);
            }
            _cartRepo.ChangeQuantities(cartItems);
        }

        public void RemoveItem(int cartItemId)
        {
            CartItem item = _cartRepo.GetCartItem(cartItemId);
            _cartRepo.RemoveItem(item);
        }
        public void ClearCart(int UserId)
        {
            
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
    }
}