namespace BookCave.Data.EntityModels
{
    public class BookDetails
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Description { get; set; }
        public string Font { get; set; }
        public int PageCount { get; set; }
        public int Length { get; set; }
    }
}