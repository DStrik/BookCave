using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class EmployeeRegisterInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserType { get; set; }
    }
}