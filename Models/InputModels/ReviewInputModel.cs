using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class ReviewInputModel
    {
        [Required]
        public int? BookId { get; set; }
        [Required]
        public double? Rating { get; set; }
        public string Review { get; set; }
    }
}