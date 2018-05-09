using System.Collections.Generic;
using BookCave.Data;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using System.Linq;
using BookCave.Data.EntityModels;
using System.IO;

namespace BookCave.Repositories
{
    public class UserRepo
    {
        private DataContext _db;

        public UserRepo()
        {
            _db = new DataContext();
        }

        public void addDefaultImage(AccountImage acImg, string id)
        {
            acImg.Img = GetDefaultImageAsync();

            if(ContainsImage(id))
            {
                acImg.Id = GetImageId(id);
                _db.Update(acImg);
            }
            else
            {
                _db.Add(acImg);
            }

            _db.SaveChanges();   
        }

        public void AddImage(AccountImage input, string id)
        {
            if(ContainsImage(id))
            {
                input.Id = GetImageId(id);
                _db.Update(input);
            }
            else
            {
                _db.Add(input);
            }

            _db.SaveChanges();   
        }

        private bool ContainsImage(string id)
        {
            var check = _db.AccountImages.Any(n => n.UserId == id);

            if(check == true)
            {
                return true;
            }

            return false;
        }

        private int GetImageId(string id)
        {
            var dbId = (from num in _db.AccountImages
                       where num.UserId == id
                       select num.Id).SingleOrDefault();

            return dbId;
        }

        private byte[] GetDefaultImageAsync()
        {       
            using (var memoryStream = new MemoryStream())
            {
                new FileInfo("wwwroot/images/default_pic.jpg").OpenRead().CopyTo(memoryStream);
                var image =  memoryStream.ToArray();
                return image;
            }
        }

        public void ChangePaymentInformation(PaymentInputModel PInfo, int UserId)
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

        public void ChangeShippingBillingInformation(ShippingBilling input, string id)
        {
            if(ContainsShippingBilling(id))
            {
                input.Id = ContainingId(id);
                _db.Update(input);
            }
            else
            {
                _db.Add(input);
            }

            _db.SaveChanges();

        }

        private bool ContainsShippingBilling(string id)
        {
            var check = _db.ShippingBillingInfo.Any(n => n.UserId == id);

            if(check == true)
            {
                return true;
            }

            return false;
        }

        private int ContainingId(string id)
        {
            var dbId = (from num in _db.ShippingBillingInfo
                       where num.UserId == id
                       select num.Id).SingleOrDefault();

            return dbId;
        }

        public AccountImage GetUserImage(string id)
        {
            var retVal = (from img in _db.AccountImages
                         where img.UserId == id
                         select img).SingleOrDefault();
            
            return retVal;
        }
    }
}