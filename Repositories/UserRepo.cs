using System.Collections.Generic;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class UserRepo
    {
        public void ChangeImage(string ImgUrl, int UserId)
        {

        }

        public void ChangePaymentInformation(PaymentInputModel pinfo, int UserId)
        {

        }

        public void ChangeShippingBillingInformation(ShippingBillingInputModel sbinfo, int UserId)
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
    }
}