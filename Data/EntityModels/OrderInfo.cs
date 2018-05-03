using BookCave.Models.ViewModels;
namespace BookCave.Data.EntityModels
{
    public class OrderInfo
    {
        public int OrderId { get; set; }
        public ShippingBillingViewModel ShippingBillingInformation { get; set; }
    }
}