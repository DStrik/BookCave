using System.Collections.Generic;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
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

        public void WriteOrder(Order order)
        {

        }

        public void DeleteOrder(int OrderId)
        {

        }
        



    }
}