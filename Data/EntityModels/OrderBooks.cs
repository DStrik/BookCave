using System.Collections.Generic;
using BookCave.Models.ViewModels;

namespace BookCave.Data.EntityModels
{
    public class OrderBooks
    {
        public int OrderId { get; set; }
        public List<BookViewModel> Books { get; set; }
    }
}