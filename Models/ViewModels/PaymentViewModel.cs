using System;
namespace BookCave.Models.ViewModels
{
    public class PaymentViewModel
    {
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvc { get; set; }
    }
}