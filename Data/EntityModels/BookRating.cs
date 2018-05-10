namespace BookCave.Data.EntityModels
{
    public class BookRating
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public double Rating { get; set; }
    }
}