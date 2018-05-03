namespace BookCave.Data.EntityModels
{
    public class HardCover
    {
        public int HcId { get; set; }
        public int BookId { get; set; }
        public int Isbn { get; set; }
        public int PublishingYear { get; set; }
        public string Font { get; set; }
        public int PageCount { get; set; }
        public double Price { get; set; }
    }
}