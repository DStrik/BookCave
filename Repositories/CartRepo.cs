using System.Collections.Generic;
using BookCave.Data;
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
        public List<int> GetCart(int UserId)
        {
            return new List<int>();
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