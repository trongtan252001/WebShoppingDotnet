using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShoppingDotnet.Models;
using WebShoppingDotnet.Services;

namespace WebShoppingDotnet.Controllers
{
    public class HomeController : Controller
    {
        ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();

        public IActionResult Index()
        {
            IHomeService homeService = new HomeServices();
            Bosutap _bst1 = _shopthoitrang.Bosutaps.First();
            Bosutap _bst2 = _shopthoitrang.Bosutaps.Skip(1).First();

            ViewBag.BoSuuTap1 = _bst1;
            ViewBag.BoSuuTap2 = _bst2;
            ViewBag.ListBST1 = _shopthoitrang.Products
                .Where(s=>s.Trangthai==1&& s.IdboSuuTap==_bst1.IdBst)
                .OrderByDescending(x => x.Ngaynhap)
                .Include(x => x.Hinhanhs)
                .Take(10).ToList();
            ViewBag.ListBST2 = _shopthoitrang.Products
                .Where(s => s.Trangthai == 1 && s.IdboSuuTap == _bst2.IdBst)
                .Include(x=>x.Hinhanhs)
                .OrderByDescending(x => x.Ngaynhap)
                .Take(10).ToList();
            ViewBag.FeaturedProducts = homeService.GetFeaturedProducts(8);
            return View(_shopthoitrang.Quangcaos.ToList());
        }
    }
}