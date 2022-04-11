using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.Models;
namespace WebShoppingDotnet.Controllers
{
    public class HomeController : Controller
    {
        ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();

        public IActionResult Index()
        {
            Console.WriteLine("Any String");

            System.Diagnostics.Debug.WriteLine(_shopthoitrang.Quangcaos.ToList().Count());
            return View(_shopthoitrang.Quangcaos.ToList());
        }
    }
}
