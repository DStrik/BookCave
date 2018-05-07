namespace BookCave.Models.ViewModels
{
    public class BookListViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Isbn { get; set; }
        public string Type { get; set; }
        public int PublishingYear { get; set; }
    }
}