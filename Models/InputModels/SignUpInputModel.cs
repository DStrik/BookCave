namespace BookCave.Models.InputModels
{
    public class SignUpInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool TermsAndConditions { get; set; }
    }
}