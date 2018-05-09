namespace BookCave.Data.EntityModels
{
    public class ProfileImage
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public byte[] Img { get; set; }
    }
}