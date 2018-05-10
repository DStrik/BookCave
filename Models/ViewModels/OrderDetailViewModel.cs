using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public List<BooksInOrderViewModel> Books { get; set; }
        public ShippingBillingViewModel ShippingBillingInfo { get; set; }
        public PaymentViewModel PaymentInfo { get; set; }
    }
}