using Microsoft.AspNetCore.Mvc;

namespace WebShoppingDotnet.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
