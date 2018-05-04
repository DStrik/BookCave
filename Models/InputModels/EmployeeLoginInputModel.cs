using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class EmployeeLoginInputModel
    {
        [EmailAddress]
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}