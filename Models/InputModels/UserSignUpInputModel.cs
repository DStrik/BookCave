using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class UserSignUpInputModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool TermsAndConditions { get; set; }
    }
}