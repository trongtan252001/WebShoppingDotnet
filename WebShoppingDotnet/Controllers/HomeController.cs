using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.Models;
namespace WebShoppingDotnet.Controllers
{
    public class HomeController : Controller
    {
        ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();

        public IActionResult Index()
        {
            ViewBag.BoSuuTap1 = _shopthoitrang.Bosutaps.First();
            ViewBag.BoSuuTap2 = _shopthoitrang.Bosutaps.Skip(1).First();
            ViewBag.ListBST1 = _shopthoitrang.Products.Where(s=>s.Trangthai==1).OrderByDescending(x => x.Ngaynhap).Take(10).ToList();
            return View(_shopthoitrang.Quangcaos.ToList());
        }
    }
}
