using System.Collections.Generic;

namespace BookCave.Data.EntityModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; }
    }
}