using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public List<AuthorViewModel> Author { get; set; }
        public PublisherViewModel Publisher { get; set; }
        public List<GenreViewModel> Genre { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string Font { get; set; }
        public int PageCount { get; set; }
        public int Length { get; set; }
        public List<ReviewViewModel> Review { get; set; }
        public List<string> Images { get; set; }
        public string CoverImage { get; set; }
        

    }
}