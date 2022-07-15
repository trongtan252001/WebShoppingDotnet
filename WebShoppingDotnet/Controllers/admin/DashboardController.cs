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
            ViewData["sp"] = _shopthoitrang.Products.OrderByDescending(p=> p.Dongia).Include(p => p.Hinhanhs).ToList().Take(10).ToList();
            ViewData["thd"] = _shopthoitrang.Hoadons.Count();
            var list = _shopthoitrang.Products.ToList();
            var totalProduct = 0;
            foreach(var item in list)
            {
                totalProduct += item.Xl + item.L + item.M + item.S;

            }
            ViewData["tsp"] = totalProduct;
            ViewData["tkh"] = _shopthoitrang.Users.Count();
            var listHodon = _shopthoitrang.Hoadons.ToList();
            double sum = 0;
            foreach (var item in listHodon)
            {
                if(item.TrangThai == 4)
                {
                    sum += item.TongTien;
                }   

            }
            ViewData["tdt"] = sum;
            var listHodon2 = _shopthoitrang.Hoadons.OrderByDescending(p=> p.NgayDatHang).Take(20).ToList();
            List<HoaDonS> hoad = new List<HoaDonS>();
            foreach (var item in listHodon2)
            {
                var user = _shopthoitrang.Users.Where(u => u.Id.Equals(item.Iduser)).First();
                HoaDonS h = new HoaDonS();
                h.user = user;
                h.hoadon = item;
                hoad.Add(h);

            }
            ViewData["hd"] = hoad;

            return View();
        }
    }
}
