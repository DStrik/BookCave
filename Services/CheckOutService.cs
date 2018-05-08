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
        public ShippingBillingViewModel GetShippingBillingViewModel(string id)
        {
            ShippingBillingViewModel data = _userRepo.GetShippingBilling(id);
            return data;
        }
    }
}