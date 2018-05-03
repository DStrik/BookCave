using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public void ChangeQuantity(int BookId)
        {

        }
        public void RemoveBook(int BookId)
        {

        }
        public void ClearCart()
        {
            
        }
    }
}