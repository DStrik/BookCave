using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class BookModifyViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Isbn { get; set; }
        public List<int> Author { get; set; }
        public List<int> Genre { get; set; }
        public int PublisherId { get; set; } 
        public string Description { get; set; }
        public List<string> Image { get; set; }
        public string CoverImage { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public int PublishingYear { get; set; }
        public string Font { get; set; }
        public int PageCount { get; set; }
        public int Length { get; set; }
    }
}