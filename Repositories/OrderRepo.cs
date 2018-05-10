using System.Collections.Generic;
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
            return new List<OrderViewModel>();
        }

        public List<OrderViewModel> GetOrderHistory(int UserId)
        {
            return new List<OrderViewModel>();
        }

        public OrderDetailViewModel GetOrderDetails(int Id)
        {
            return new OrderDetailViewModel();
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

    }
}