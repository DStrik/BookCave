namespace BookCave.Data.EntityModels
{
    public class Stock
    {
        public int Id { get; set; }
        public int BookTypeId { get; set; }
        public int Quantity { get; set; }
    }
}