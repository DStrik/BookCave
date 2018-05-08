using System.Collections.Generic;

namespace BookCave.Data.EntityModels
{
    public class CartItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }
        
    }
}