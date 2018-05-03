namespace BookCave.Models.InputModels
{
    public class BillingInputModel
    {
        public string BillingFirstName { get; set; }
        public string BillingLastName { get; set; }
        public string BillingStreetName { get; set; }
        public int BillingHouseNumber { get; set; }
        public string BillingCity { get; set; }
        public string BillingZipCode { get; set; }
        public string BillingCountry { get; set; }
    }
}