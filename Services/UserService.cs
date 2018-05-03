using System.Collections.Generic;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;

namespace BookCave.Services
{
    public class UserService
    {
        public void Login(string Name, string pw)
        {

        }
        public void SignUp(UserInputModel user)
        {
            
        }
        public List<OrderViewModel> GetOrderHistory(int UserId)
        {
            return null;
        }
        public List<BookViewModel> GetWishlist(int UserId)
        {
            return null;
        }
        public void AddToWishlist(int BookId)
        {

        }
        public void RemoveFromWishlist(int BookId)
        {

        }
        public void ChangeImage(string ImgUrl)
        {

        }
        public void ChangePassword(PasswordInputModel pw)
        {

        }
        
    }
}