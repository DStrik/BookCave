namespace BookCave.Data.EntityModels
{
    public class EBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Isbn { get; set; }
        public int PublishingYear { get; set; }
        public double Price { get; set; }
    }
}