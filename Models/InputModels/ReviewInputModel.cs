namespace BookCave.Models.InputModels
{
    public class ReviewInputModel
    {
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}