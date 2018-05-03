namespace BookCave.Models.InputModels
{
    public class ShippingBillingInputModel
    {
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingStreetName { get; set; }
        public int ShippingHouseNumber { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingZipCode { get; set; }
        public string ShippingCountry { get; set; }

    }
}