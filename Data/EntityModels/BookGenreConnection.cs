namespace BookCave.Data.EntityModels
{
    public class BookGenreConnection
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
    }
}