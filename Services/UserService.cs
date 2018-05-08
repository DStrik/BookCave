using System.Collections.Generic;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class UserService
    {
        private UserRepo _userRepo;

        public UserService()
        {
            _userRepo = new UserRepo();
        }

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
        
        public void ChangeShippingInfo(ShippingInputModel ShipInfo)
        {

        }

        public void ChangeBillingInfo(BillingInputModel BillInfo)
        {

        }
        
        public ShippingBillingViewModel GetShippingBillingInfo(string id)
        {
            return _userRepo.GetShippingBilling(id);
        }

        public void GetBillingInfo(int id)
        {

        }
        
        public void ChangePaymentInfo(PaymentInputModel PayInfo)
        {
            
        }
    }
}