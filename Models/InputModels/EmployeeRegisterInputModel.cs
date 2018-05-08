using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class EmployeeRegisterInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string UserType { get; set; }
    }
}