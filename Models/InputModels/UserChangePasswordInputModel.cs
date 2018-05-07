namespace BookCave.Models.InputModels
{
    public class UserChangePasswordInputModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}