using Microsoft.AspNetCore.Mvc;

namespace WebShoppingDotnet.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
