using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.Controllers.admin
{
    public class DetailProductAdminController : Controller
    {
        ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();

        public IActionResult Index(string m)
        {
            var type = _shopthoitrang.Loaisps.ToList();
            var bst = _shopthoitrang.Bosutaps.ToList();
            ViewData["type"] = type;
            ViewData["bst"] = bst;
            var product = _shopthoitrang.Products.Single(p => p.Masp.Equals(m));
            ViewData["hinhanh"] = _shopthoitrang.Hinhanhs.Where(h => h.Idsp.Equals(m)).ToList();
            return View(product);
        }
    }
}
