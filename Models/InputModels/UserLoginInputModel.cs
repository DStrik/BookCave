using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class UserLoginInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}