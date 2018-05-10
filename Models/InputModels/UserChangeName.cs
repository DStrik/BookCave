using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class UserChangeName
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}