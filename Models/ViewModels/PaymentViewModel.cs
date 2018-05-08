using System;
namespace BookCave.Models.ViewModels
{
    public class PaymentViewModel
    {
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Cvc { get; set; }
    }
}