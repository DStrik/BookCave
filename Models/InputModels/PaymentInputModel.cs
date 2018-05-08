using System;

namespace BookCave.Models.InputModels
{
    public class PaymentInputModel
    {
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Cvc { get; set; }
    }
}