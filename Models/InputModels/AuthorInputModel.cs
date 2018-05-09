using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class AuthorInputModel
    {
        [Required(ErrorMessage="Author's name is missing!")]
        public string Name { get; set; }
    }
}