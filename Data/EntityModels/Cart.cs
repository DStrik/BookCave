using System.Collections.Generic;

namespace BookCave.Data.EntityModels
{
    public class Cart
    {
        public int UserId { get; set; }
        public List<int> Books { get; set; }
    }
}