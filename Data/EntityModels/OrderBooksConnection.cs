using System.Collections.Generic;
using BookCave.Models.ViewModels;

namespace BookCave.Data.EntityModels
{
    public class OrderBooksConnection
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
    }
}