using Microsoft.AspNetCore.Mvc;

namespace WebShoppingDotnet.Views
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
