using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public List<BookViewModel> Books { get; set; }
        public ShippingBillingViewModel ShippingBillingInfo { get; set; }
    }
}