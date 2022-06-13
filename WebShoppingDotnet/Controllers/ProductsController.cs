using Microsoft.AspNetCore.Mvc;

namespace WebShoppingDotnet.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
