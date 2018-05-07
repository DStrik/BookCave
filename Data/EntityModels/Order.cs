using System;
namespace BookCave.Data.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}