using BookCave.Models.ViewModels;
namespace BookCave.Data.EntityModels
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public ShippingBillingViewModel ShippingBillingInformation { get; set; }
    }
}