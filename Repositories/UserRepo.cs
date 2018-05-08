using System.Collections.Generic;
using BookCave.Data;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using System.Linq;

namespace BookCave.Repositories
{
    public class UserRepo
    {
        private DataContext _db;

        public UserRepo()
        {
            _db = new DataContext();
        }
        public void ChangeImage(string ImgUrl, int UserId)
        {

        }

        public void ChangePaymentInformation(PaymentInputModel PInfo, int UserId)
        {

        }

        public void ChangeShippingBillingInformation(ShippingInputModel ShippingInput, BillingInputModel BillingInput, int UserId)
        {

        }

        public List<BookViewModel> GetWishlist(int UserId)
        {
            return new List<BookViewModel>();
        }

        public void AddToWishlist(int BookTypeId, int UserId)
        {

        }

        public void RemoveFromWishlist(int BookTypeId, int UserId)
        {

        }

        public ShippingBillingViewModel GetShippingBilling (string id)
        {
            var result = (from sb in _db.ShippingBillingInfo
                          where sb.UserId == id
                          select new ShippingBillingViewModel
                          {
                              ShippingFirstName = sb.ShippingFirstName,
                              ShippingLastName = sb.ShippingLastName,
                              ShippingStreetName = sb.ShippingStreetName,
                              ShippingHouseNumber = sb.ShippingHouseNumber,
                              ShippingCity = sb.ShippingCity,
                              ShippingZipCode = sb.ShippingZipCode,
                              ShippingCountry = sb.ShippingCountry,
                              BillingFirstName = sb.BillingFirstName,
                              BillingLastName = sb.BillingLastName,
                              BillingStreetName = sb.BillingStreetName,
                              BillingHouseNumber = sb.BillingHouseNumber,
                              BillingCity = sb.BillingCity,
                              BillingZipCode = sb.BillingZipCode,
                              BillingCountry = sb.BillingCounry,
                          }).SingleOrDefault();
            return result;
        }
    }
}