using BookCave.Models.ViewModels;
namespace BookCave.Data.EntityModels
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingStreetName { get; set; }
        public int ShippingHouseNumber { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingZipCode { get; set; }
        public string ShippingCountry { get; set; }
        public string BillingFirstName { get; set; }
        public string BillingLastName { get; set; }
        public string BillingStreetName { get; set; }
        public int BillingHouseNumber { get; set; }
        public string BillingCity { get; set; }
        public string BillingZipCode { get; set; }
        public string BillingCounry { get; set; }
        public string PaymentFullName { get; set; }
        public string PaymentCardNumber { get; set; }
        public string PaymentExpirationMonth { get; set; }
        public string PaymentExpirationYear { get; set; }
    }
}