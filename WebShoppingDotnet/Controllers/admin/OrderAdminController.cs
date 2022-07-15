using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebShoppingDotnet.Helpers;
using WebShoppingDotnet.Views;
namespace WebShoppingDotnet.Controllers.admin
{
    public class OrderAdminController : Controller
    {
        private ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
        public async Task<IActionResult> Index(int? p,int? s,string? n)
        {
            var hoadDon = _shopthoitrang.Hoadons.Where(p => 1 == 1);


            if ((s + "").Length > 0 && s != -1)
            {
                hoadDon = hoadDon.Where(p => p.TrangThai == s);
            }
           
            if ((n + "").Length > 0)
            {
                DateTime dateOnly = DateTime.Parse(n);
                hoadDon = hoadDon.Where(p => p.NgayDatHang == dateOnly);
            }


            var list = await PaginatedList<Hoadon>.CreateAsync(hoadDon.AsNoTracking(), p ?? 1, 10);
            List<HoaDonS> result = new List<HoaDonS>();
            foreach (var h in list)
            {
                var user = _shopthoitrang.Users.Where(p => p.Id.Equals(h.Iduser)).First();
                HoaDonS hoaDonS = new HoaDonS();
                hoaDonS.user = user;
                hoaDonS.hoadon = h;
                result.Add(hoaDonS);

            }
            var totalItems = await hoadDon.CountAsync();
            ViewData["TotalPage"] = totalItems % 16 == 0 ? totalItems / 16 : totalItems / 16 + 1;
            ViewData["page"] = p;
            return View(result);
        }
        public async Task<IActionResult> Detail(string? m)
        {
            var hoadDon =  _shopthoitrang.Hoadons.Where(p => p.Mahoadon.Equals(m)).First();
            var user = _shopthoitrang.Users.Include(u => u.Khachhang).Where(p => p.Id.Equals(hoadDon.Iduser)).First();
            HoaDonS hoaDonS = new HoaDonS();
            hoaDonS.user = user;
            hoaDonS.hoadon = hoadDon;
           var list = _shopthoitrang.Cthoadons.Where(c=> c.MaHd.Equals(m)).ToList();
            List<DetailOrder> result = new List<DetailOrder>();
            foreach (var hoaDon in list)
            {
                var img = _shopthoitrang.Hinhanhs.Where(h => h.Idsp.Equals(hoaDon.MaSp)).First();
                DetailOrder d = new DetailOrder();
                d.urlImg = img.Url;
                d.cthoadon = hoaDon;
                result.Add(d);
            }
            ViewData["dssp"] = result;
            @ViewData["maso"] = m;
            return View( hoaDonS);
        }
        [HttpPost]
        public String updateStatus(string? maDonHang, int soNgay  ,int status)
        {
            var hoaDon = _shopthoitrang.Hoadons.Where(h => h.Mahoadon.Equals(maDonHang)).First();
            hoaDon.TrangThai = status;

            if (status == 2 && soNgay != -1)
            {
                hoaDon.SoNgayDuKien = soNgay;
                TimeSpan aInterval = new System.TimeSpan(soNgay, 0,0, 0);
                DateTime today = DateTime.Today;
                hoaDon.NgayNhanHang = today.Add(aInterval);
            }
            if (status == 1)
            {
                DateTime today = DateTime.Today;
                hoaDon.NgayNhanHang = today;
            }
            
                _shopthoitrang.SaveChanges();

            return "success";
        }
    }
}
