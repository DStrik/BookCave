namespace BookCave.Data.EntityModels
{
    public class BookReview
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Grade { get; set; }
        public string Review { get; set; }
    }
}