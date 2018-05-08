using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class UserChangePasswordInputModel
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}