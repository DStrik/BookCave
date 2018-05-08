using System.Collections.Generic;
using BookCave.Data.EntityModels;
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
        
        public void ChangeShippingBillingInfo(ShippingBillingInputModel input, string id)
        {
            ShippingBilling write = new ShippingBilling()
            {
                UserId = id,
                ShippingFirstName = input.ShippingFirstName,
                ShippingLastName = input.ShippingLastName,
                ShippingStreetName = input.ShippingStreetName,
                ShippingHouseNumber = input.ShippingHouseNumber,
                ShippingCity = input.ShippingCity,
                ShippingZipCode = input.ShippingCity,
                ShippingCountry = input.ShippingCountry,

                BillingFirstName = input.BillingFirstName,
                BillingLastName = input.BillingLastName,
                BillingStreetName = input.BillingStreetName,
                BillingHouseNumber = input.BillingHouseNumber,
                BillingCity = input.BillingCity,
                BillingZipCode = input.BillingCity,
                BillingCounry = input.BillingCountry
            };

            _userRepo.ChangeShippingBillingInformation(write);
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