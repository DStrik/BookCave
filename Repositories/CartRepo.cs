using System.Collections.Generic;
using BookCave.Data;
using System.Linq;
using BookCave.Data.EntityModels;

namespace BookCave.Repositories
{
    public class CartRepo
    {
        private DataContext _db;
        public CartRepo()
        {
            _db = new DataContext();
        }
        public List<CartItem> GetCart(string UserId)
        {
            var cartItems = (from i in _db.CartItems
                            where i.UserId == UserId
                            select i).ToList();
            return cartItems;
        }
        public CartItem GetCartItem(int cartItemId, string userId)
        {
            var cartItem = (from i in _db.CartItems
                            where i.Id == cartItemId
                            where i.UserId == userId
                            select i).SingleOrDefault();
            return cartItem;
        }

        public void ChangeQuantities(List<CartItem> items)
        {
            foreach(CartItem i in items)
            {
                _db.Update(i);
            }
            _db.SaveChanges();
        }
        public void ChangeQuantity(CartItem item)
        {
            _db.Update(item);
            _db.SaveChanges();
        }

        public void RemoveItem(CartItem item)
        {
            _db.Remove(item);
            _db.SaveChanges();
        }

        public void RemoveBookFromCarts(int bookId)
        {
            var cartItems = GetCartItemsByBookId(bookId);
            foreach(var c in cartItems)
            {
                RemoveItem(c);
            }
        }

        private List<CartItem> GetCartItemsByBookId(int bookId)
        {
            var items = (from c in _db.CartItems
                       where c.BookId == bookId
                       select c).ToList();
            return items;
        }

        public void ClearCart(string userId)
        {
            var items = (from c in _db.CartItems
                         where c.UserId == userId
                         select c).ToList();

            foreach(CartItem i in items)
            {
                _db.Remove(i);
            }
            _db.SaveChanges();
        }
        public void AddToCart(CartItem item)
        {
            _db.Add(item);
            _db.SaveChanges();
        }
        public bool Contains(string userId, int bookId)
        {
            var item = (from i in _db.CartItems
                        where i.UserId == userId && i.BookId == bookId
                        select i).SingleOrDefault();
            if(item == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public CartItem GetCartItemByIds(string userId, int bookId)
        {
            var item = (from i in _db.CartItems
                        where i.UserId == userId && i.BookId == bookId
                        select i).SingleOrDefault();
            return item;
        }
    }
}