using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class UserService
    {
        private UserRepo _userRepo;
        private OrderRepo _orderRepo;

        public UserService()
        {
            _userRepo = new UserRepo();
            _orderRepo = new OrderRepo();
        }
        
        public List<OrderViewModel> GetOrderHistory(string userId)
        {
            return _orderRepo.GetOrderHistory(userId);
        }
        public OrderDetailViewModel GetOrderDetails(int orderId, string userId)
        {
            return _orderRepo.GetOrderDetails(orderId, userId);
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
        public void ChangePaymentInfo(PaymentInputModel PayInfo)
        {
            //geyma
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

        public async Task<bool> ChangeImage(AccountViewModel input, string id)
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
                
                return true;
            }
        }
    }
}