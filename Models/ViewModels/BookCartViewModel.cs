using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class BookCartViewModel
    {
        public int BookId { get; set; }
        public int CartItemId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public byte[] CoverImage { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}