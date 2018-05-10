namespace BookCave.Models.ViewModels
{
    public class ReviewViewModel
    {
        public string Reviewer { get; set;}
        public double Rating { get; set; }
        public string Review { get; set; }
        public byte[] ProfileImg { get; set; }
    }
}