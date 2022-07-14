using Microsoft.AspNetCore.Mvc;

namespace WebShoppingDotnet.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
