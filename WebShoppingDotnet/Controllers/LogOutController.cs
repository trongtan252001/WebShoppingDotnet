using Microsoft.AspNetCore.Mvc;

namespace WebShoppingDotnet.Controllers
{
    public class LogOutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index","Home");
        }
    }
}
