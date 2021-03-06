using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class BookDetailViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        public string Isbn { get; set; }
        public List<AuthorViewModel> Author { get; set; }
        public PublisherViewModel Publisher { get; set; }
        public List<GenreViewModel> Genre { get; set; }
        public int PublishingYear { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string Font { get; set; }
        public int PageCount { get; set; }
        public int Length { get; set; }
        public List<ReviewViewModel> Review { get; set; }
        public double Rating { get; set; }
        public byte[] CoverImage { get; set; }
        public byte[] UserImage { get; set; }
        
    }
}