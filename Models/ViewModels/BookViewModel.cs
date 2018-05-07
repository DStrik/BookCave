using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public List<AuthorViewModel> Author { get; set; }
        public int Isbn { get; set; }
        public string Type { get; set; }
        public List<GenreViewModel> Genre { get; set; }
        public int PublishingYear { get; set; }
        public byte[] CoverImage { get; set; }
        public double Price { get; set; }
    }
}