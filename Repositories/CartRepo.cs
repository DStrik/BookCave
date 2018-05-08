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
        public List<int> GetCart(string UserId)
        {
            var cartItems = (from i in _db.CartItems
                            where i.UserId == UserId
                            select i.BookId).ToList();
            return cartItems;
        }

        public void ChangeQuantity(int BookTypeId, int UserId)
        {

        }

        public void RemoveBook(int BookTypeId, int UserId)
        {

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