using System;

namespace BookCave.Data.EntityModels
{
    public class Payment
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int CardNumber { get; set; } 
        public DateTime ExpirationDate { get; set; }
        public int Cvc { get; set; }
    }
}