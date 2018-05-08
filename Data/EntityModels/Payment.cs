using System;

namespace BookCave.Data.EntityModels
{
    public class Payment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; } 
        public DateTime ExpirationDate { get; set; }
        public string Cvc { get; set; }
    }
}