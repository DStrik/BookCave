namespace BookCave.Data.EntityModels
{
    public class CoverImage
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public byte[] Img { get; set; }
    }
}