using System;

namespace BookCave.Models.InputModels
{
    public class PaymentInputModel
    {
        public string FullName { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Cvc { get; set; }
    }
}