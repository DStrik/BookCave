using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        DataContext _db;
        public OrderRepo()
        {
            _db = new DataContext();
        }
        public List<OrderViewModel> GetAllOrders()
        {
            var orders = new List<OrderViewModel>();
            foreach(Order o in _db.Orders)
            {
                var order = new OrderViewModel
                {
                    Id = o.Id,
                    DateOfPurchase = o.DateOfPurchase

                };
                orders.Add(order);
            }
            return orders;
        }

        public List<OrderViewModel> GetOrderHistory(string userId)
        {   
            var orders = (from o in _db.Orders
                        where o.UserId == userId
                            select o).ToList();

            var ordersView = new List<OrderViewModel>();
            foreach(Order o in orders)
            {
                var order = new OrderViewModel
                {
                    Id = o.Id,
                    DateOfPurchase = o.DateOfPurchase
                };
                ordersView.Add(order);
            }
            return ordersView;
        }

        public OrderDetailViewModel GetOrderDetails(int orderId)
        {
            var order = (from o in _db.OrderInfo
                        where orderId == o.OrderId
                        select o).SingleOrDefault();
            var orderedBooks = GetBooks(orderId);
            var orderInfo = GetOrderInfo(orderId);
            var shippingBillingInfo = GetShippingBilling(orderInfo);
            var paymentInfo = Payment(orderInfo);
            var orderDetailed = new OrderDetailViewModel
            {
                Id = order.Id,
                Books = orderedBooks,
                ShippingBillingInfo = shippingBillingInfo,
                PaymentInfo = paymentInfo
            };

            return orderDetailed;
        }

        public int WriteOrder(Order order)
        {
            _db.Add(order);
            _db.SaveChanges();
            return order.Id;
        }

        public void DeleteOrder(int OrderId)
        {

        }
        
        public void AddBookOrderConnection(BooksInOrder bio)
        {
            _db.Add(bio);
            _db.SaveChanges();
        }

        public void AddOrderInfo(OrderInfo oi)
        {
            _db.Add(oi);
            _db.SaveChanges();
        }
        private List<BooksInOrderViewModel> GetBooks(int orderId)
        {
            var books = (from bio in _db.BooksInOrder
                           where bio.OrderId == orderId
                           select new BooksInOrderViewModel
                           {
                                Title = bio.Title,
                                Price = bio.Price,
                                Quantity = bio.Quantity

                           }).ToList();
            return books; 
        }
        private OrderInfo GetOrderInfo(int orderId)
        {
            var order = (from oi in _db.OrderInfo
                        where oi.OrderId == orderId
                        select oi).SingleOrDefault();
            return order;
        }
        private ShippingBillingViewModel GetShippingBilling(OrderInfo info)
        {
            var view = new ShippingBillingViewModel
            {
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
                BillingCountry = info.BillingCounry,
            };

            return view;
        }
        private PaymentViewModel Payment(OrderInfo info)
        {
            var view = new PaymentViewModel
            {
            FullName = info.PaymentFullName,
            CardNumber = info.PaymentCardNumber,
            ExpirationMonth = info.PaymentExpirationMonth,
            ExpirationYear = info.PaymentExpirationYear
            };

            return view;
        }

    }
}