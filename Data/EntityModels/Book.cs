using System.Collections.Generic;

namespace BookCave.Data.EntityModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public int PublishingYear { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int PublisherId { get; set; }
    }
}