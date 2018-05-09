using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class GenreInputModel
    {
        [Required(ErrorMessage="Genre name is missing!")]
        public string Name { get; set; }
    }
}