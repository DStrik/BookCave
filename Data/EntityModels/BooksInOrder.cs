namespace BookCave.Data.EntityModels
{
    public class BooksInOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}