namespace BookCave.Models.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string ImgUrl { get; set; }
        public BookViewModel FavBook { get; set; }
    }
}