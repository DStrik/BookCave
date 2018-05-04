using System.Collections.Generic;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;

namespace BookCave.Services
{
    public class ManageService
    {
        public List<OrderViewModel> GetOrders()
        {
            return null;
        }
        public List<OrderViewModel> GetOrders(string Order)
        {
            return null;
        }
        public void ModifyOrder(List<BookViewModel> Orders)
        {

        }
        public void AddToStock(int qty, int BookId)
        {

        }
        public List<BookViewModel> ViewStock()
        {
            return null;
        }
        public void ChangePassword(string CurrentPw, string NewPw, string ConfirmedPw, int EmpId)
        {

        }
        public void DeleteBook(int BookId)
        {

        }
        public OrderDetailViewModel GetOrderDetails()
        {
            return null;
        }
        public void DeleteOrder(int OrderId)
        {

        }
        public void AddNewEmp(EmployeeRegisterInputModel emp)
        {
            
        }
        public EmployeeRegisterInputModel GetEmployeeInput(int EmpId)
        {
            return null;
        }
        public void DeleteEmp(int EmpId)
        {

        }
        public void Login(string UserName, string Password)
        {

        }
        public void Logout()
        {
            
        }

    }
}