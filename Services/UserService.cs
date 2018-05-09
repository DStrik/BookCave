using System.Collections.Generic;
using System.IO;
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

            _userRepo.ChangeShippingBillingInformation(write, id);
        }
        
        public ShippingBillingInputModel GetShippingBillingInfo(string id)
        {
            var viewmodel = _userRepo.GetShippingBilling(id);

            if(viewmodel == null)
            {
                return null;
            }

            var inputmodel = new ShippingBillingInputModel() {
                ShippingFirstName = viewmodel.ShippingFirstName,
                ShippingLastName = viewmodel.ShippingLastName,
                ShippingStreetName = viewmodel.ShippingStreetName,
                ShippingHouseNumber = viewmodel.ShippingHouseNumber,
                ShippingCity = viewmodel.ShippingCity,
                ShippingZipCode = viewmodel.ShippingCity,
                ShippingCountry = viewmodel.ShippingCountry,

                BillingFirstName = viewmodel.BillingFirstName,
                BillingLastName = viewmodel.BillingLastName,
                BillingStreetName = viewmodel.BillingStreetName,
                BillingHouseNumber = viewmodel.BillingHouseNumber,
                BillingCity = viewmodel.BillingCity,
                BillingZipCode = viewmodel.BillingCity,
                BillingCountry = viewmodel.BillingCountry
            };

            return inputmodel;
        }

        public void GetBillingInfo(int id)
        {

        }
        
        public void ChangePaymentInfo(PaymentInputModel PayInfo)
        {
            
        }

        public void addDefaultImage(string id)
        {
            _userRepo.addDefaultImage(new AccountImage(){
                UserId = id,
            }, id);
        }

        public AccountViewModel GetUserImage(string id)
        {
            var img = _userRepo.GetUserImage(id);

            return new AccountViewModel() {
                Image = img.Img,
            };
        }

        public async void ChangeImage(AccountViewModel input, string id)
        {
            using (var memoryStream = new MemoryStream())
            {
                await input.NewImage.CopyToAsync(memoryStream);
                var img = new AccountImage
                {
                    Img = memoryStream.ToArray(),
                    UserId = id,

                };

                _userRepo.AddImage(img, id);
            }
        }
    }
}