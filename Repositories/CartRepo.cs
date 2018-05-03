using System.Collections.Generic;

namespace BookCave.Repositories
{
    public class CartRepo
    {
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
    }
}