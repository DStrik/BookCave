namespace BookCave.Models.InputModels
{
    public class ModifyUserInputModel
    {
        public string OldRole { get; set; }
        public string NewRole { get; set; }
        public string UserId { get; set; }
    }
}