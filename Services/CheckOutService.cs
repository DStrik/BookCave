using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class CheckOutService
    {
        private UserRepo _userRepo;
        public CheckOutService ()
        {
            _userRepo = new UserRepo();
        }
        public void AddOrder(int UserId)
        {
            
        }
        public CheckOutInputModel GetShippingBillingViewModel(string id)
        {
            CheckOutInputModel data = new CheckOutInputModel();
            ShippingBillingViewModel shippingBilling = _userRepo.GetShippingBilling(id);
            if(shippingBilling != null)
            {
                data.ShippingFirstName = shippingBilling.ShippingFirstName;
                data.ShippingLastName = shippingBilling.ShippingLastName;
                data.ShippingStreetName = shippingBilling.ShippingStreetName;
                data.ShippingHouseNumber = shippingBilling.ShippingHouseNumber;
                data.ShippingCity = shippingBilling.ShippingCity;
                data.ShippingZipCode = shippingBilling.ShippingZipCode;
                data.ShippingCountry = shippingBilling.ShippingCountry;
                data.BillingFirstName = shippingBilling.BillingFirstName;
                data.BillingLastName = shippingBilling.BillingLastName;
                data.BillingStreetName = shippingBilling.BillingStreetName;
                data.BillingHouseNumber = shippingBilling.BillingHouseNumber;
                data.BillingCity = shippingBilling.BillingCity;
                data.BillingZipCode = shippingBilling.BillingZipCode;
                data.BillingCountry = shippingBilling.BillingCountry;
            }
            return data;
        }
    }
}