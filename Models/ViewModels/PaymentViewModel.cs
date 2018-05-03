using System;
namespace BookCave.Models.ViewModels
{
    public class PaymentViewModel
    {
        public string FullName { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Cvc { get; set; }
    }
}