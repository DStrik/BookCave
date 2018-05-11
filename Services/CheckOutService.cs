using System.Collections.Generic;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class CheckOutService
    {
        private UserRepo _userRepo;
        private CartService _cartService;
        private OrderRepo _orderRepo;
        public CheckOutService ()
        {
            _userRepo = new UserRepo();
            _cartService = new CartService();
            _orderRepo = new OrderRepo();
        }
        public void AddOrder(CheckOutInputModel info, string id)
        {
            var cart = _cartService.GetCart(id);
            var order = new Order
            {
                UserId = id,
                DateOfPurchase = System.DateTime.Today
            };

            var orderid = _orderRepo.WriteOrder(order);
            
            foreach(var n in cart)
            {
                var bio = new BooksInOrder
                {
                    OrderId = orderid,
                    Title = n.Title,
                    Price = n.Price,
                    Quantity = n.Quantity

                };
                _orderRepo.AddBookOrderConnection(bio);
            }
            var cardNumber = "xxxxxxxxxxxx";
            cardNumber += info.CardNumber.Substring(12);
            var orderInfo = new OrderInfo
            {
                OrderId = orderid,
                UserId = id,
                ShippingFirstName = info.ShippingFirstName,
                ShippingLastName = info.ShippingLastName,
                ShippingStreetName = info.ShippingStreetName,
                ShippingHouseNumber = info.ShippingHouseNumber,
                ShippingCity = info.ShippingCity,
                ShippingZipCode = info.ShippingZipCode,
                ShippingCountry = info.ShippingCountry,
                BillingFirstName = info.BillingFirstName,
                BillingLastName = info.BillingLastName,
                BillingStreetName = info.BillingStreetName,
                BillingHouseNumber = info.BillingHouseNumber,
                BillingCity = info.BillingCity,
                BillingZipCode = info.BillingZipCode,
                BillingCounry = info.BillingCountry,
                PaymentFullName = info.FullName,
                PaymentCardNumber = cardNumber,
                PaymentExpirationMonth = info.ExpirationMonth,
                PaymentExpirationYear = info.ExpirationYear,
            };
            _orderRepo.AddOrderInfo(orderInfo);
            _cartService.ClearCart(id);

   }
       public CheckOutInputModel GetShippingBillingViewModel(string id)
        {
           CheckOutInputModel data = new CheckOutInputModel();
            ShippingBillingViewModel shippingBilling = _userRepo.GetShippingBilling(id);
            if(shippingBilling != null)
            {
                data.ShippingFirstName = shippingBilling.ShippingFirstName;
                data.ShippingLastName = shippingBilling.ShippingLastName;
                data.ShippingStreetName = shippingBilling.ShippingStreetName;
                data.ShippingHouseNumber = shippingBilling.ShippingHouseNumber;
                data.ShippingCity = shippingBilling.ShippingCity;
                data.ShippingZipCode = shippingBilling.ShippingZipCode;
                data.ShippingCountry = shippingBilling.ShippingCountry;
                data.BillingFirstName = shippingBilling.BillingFirstName;
                data.BillingLastName = shippingBilling.BillingLastName;
                data.BillingStreetName = shippingBilling.BillingStreetName;
                data.BillingHouseNumber = shippingBilling.BillingHouseNumber;
                data.BillingCity = shippingBilling.BillingCity;
                data.BillingZipCode = shippingBilling.BillingZipCode;
                data.BillingCountry = shippingBilling.BillingCountry;
            }
            return data;
        }
        public List<BookCartViewModel> GetCart(string id)
        {
            return _cartService.GetCart(id);
        }
    }
}