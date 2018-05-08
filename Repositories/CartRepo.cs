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

        public void ChangeQuantity(int BookTypeId, int UserId)
        {
            
        }

        public void RemoveBook(CartItem item)
        {
            _db.Remove(item);
            _db.SaveChanges();
        }

        public void ClearCart(int UserId)
        {

        }
        public void AddToCart(CartItem item)
        {
            _db.Add(item);
            _db.SaveChanges();
        }
    }
}