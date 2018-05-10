using System;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class CheckOutInputModel
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
       
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [RegularExpression(@"^[0-9]{16}$")]
        [Required(ErrorMessage = "Valid Cart number is required")]
        public string CardNumber { get; set; }

        [RegularExpression(@"^(0[1-9]|[1-9])|1[0-2]")]
        [Required(ErrorMessage = "Month is required")]
        public string ExpirationMonth { get; set; }

        [RegularExpression(@"^1[8-9]|2[0-8]")]
        [Required(ErrorMessage = "Year is required")]
        public string ExpirationYear { get; set; }

        [RegularExpression(@"^\d{3}")]
        [Required(ErrorMessage = "Cvc is required")]
        public string Cvc { get; set; }
    }
}