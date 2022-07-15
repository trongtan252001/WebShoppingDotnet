using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.Models;
using Microsoft.EntityFrameworkCore.Query;
using WebShoppingDotnet.Helpers;
using Microsoft.EntityFrameworkCore;
namespace WebShoppingDotnet.Controllers.admin
{
    public class DashboardController : Controller
    {
        private ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
        public IActionResult Index()
        {
            ViewData["sp"] = _shopthoitrang.Products.Include(p => p.Hinhanhs).ToList().Take(10).ToList();
            ViewData["hd"] = _shopthoitrang.Users.Include(u => u.Hoadons).ToList();

            
            return View();
        }
    }
}
