using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class ShippingBillingInputModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string ShippingFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string ShippingLastName { get; set; }

        [Required(ErrorMessage = "Street name is required")]
        public string ShippingStreetName { get; set; }

        [Required(ErrorMessage = "House number is required")]
        public int ShippingHouseNumber { get; set; }

        [Required(ErrorMessage = "City name is required")]
        public string ShippingCity { get; set; }

        [Required(ErrorMessage = "Zip code is required")]
        public string ShippingZipCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string ShippingCountry { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string BillingFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string BillingLastName { get; set; }

        [Required(ErrorMessage = "Street name is required")]
        public string BillingStreetName { get; set; }

        [Required(ErrorMessage = "House number is required")]
        public int BillingHouseNumber { get; set; }

        [Required(ErrorMessage = "City name is required")]
        public string BillingCity { get; set; }

        [Required(ErrorMessage = "Zip code is required")]
        public string BillingZipCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string BillingCountry { get; set; }
    }
}