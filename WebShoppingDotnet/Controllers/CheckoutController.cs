using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebShoppingDotnet.Models;
using WebShoppingDotnet.Service;
using WebShoppingDotnet.Services;

namespace WebShoppingDotnet.Controllers
{
    public class CheckoutController : Controller
    {
        [HttpPost]
        public IActionResult Index(String? data)
        {

            List<CheckoutDTo> checkoutDtos = JsonConvert.DeserializeObject<List<CheckoutDTo>>(data);

            String jsonUser = HttpContext.Session.GetString("user");

            if (jsonUser == null || data == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                User user = JsonConvert.DeserializeObject<User>(jsonUser);
                ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
                Khachhang khachHang = IUserService.getKhachHang(user.Id);
                float total = 0;
                foreach (CheckoutDTo vDto in checkoutDtos)
                {
                    total += vDto.price * vDto.quantity;
                }

                IProductService service = new ProductService();
                ViewBag.customer1 = khachHang;
                ViewBag.total = service.ParseCurrencyVND(total);
                ViewBag.user1 = user;
                ViewBag.data = data;
            }

            return View(checkoutDtos);
        }

        public String CheckOut(String? name, String? phone, String? email, String? address, String? tinhTP,
            String? quanHuyen, String? phuongXa, String? check,String? listDTo)
        {

            String jsonUser = HttpContext.Session.GetString("user");

            if (jsonUser==null|| listDTo == null)
            {
                return "false";
            }
            User user = JsonConvert.DeserializeObject<User>(jsonUser);
            ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
            Khachhang k = _shopthoitrang.Khachhangs.First(k => k.Iduser == user.Id);
            k.DiaChi = address;
            k.HoTen = name;
            k.PhuongXa = phuongXa;
            k.QuanHuyen = quanHuyen;
            k.TinhTp = tinhTP;
            k.DienThoai = phone;
            User newUser = _shopthoitrang.Users.First(k => k.Id == user.Id);
            string newUSerJSon = JsonConvert.SerializeObject(newUser);

            HttpContext.Session.SetString("user", newUSerJSon);
            var idHD = Guid.NewGuid().ToString();
            List<CheckoutDTo> checkoutDtos = JsonConvert.DeserializeObject<List<CheckoutDTo>>(listDTo);
            double total = 0;
            foreach (CheckoutDTo vDto in checkoutDtos)
            {

                Product p = _shopthoitrang.Products.FirstOrDefault(p => p.Masp == vDto.id);
                if (p.GetSize(vDto.size)>= vDto.quantity)
                {

                    p.S = p.S-vDto.quantity;
                    float priceNow = (1 - p.GetSaleToday()) * p.Dongia;
                    Cthoadon ct = new Cthoadon()
                        {MaHd = idHD,MaSp = p.Masp,SoLuong = vDto.quantity, Price = priceNow,Size = vDto.size};
                    total += priceNow * vDto.quantity;
                    _shopthoitrang.Cthoadons.Add(ct);
                }
                else
                {
                    return "false";
                }

            }

            Hoadon hd = new Hoadon() { Mahoadon = idHD, Iduser = user.Id, NgayDatHang = DateTime.Now, TrangThai = 0, TongTien = total };
            _shopthoitrang.Hoadons.Add(hd);
            foreach (CheckoutDTo vDto in checkoutDtos)
            {
                Giohang g = _shopthoitrang.Giohangs.FirstOrDefault(g => g.Iduser == user.Id&&g.Idsp==vDto.id && g.Size == vDto.size);
                g.Soluong = g.Soluong- vDto.quantity;
                if (g.Soluong==0)
                {
                    _shopthoitrang.Giohangs.Remove(g);
                }
                
            }
            System.Diagnostics.Debug.WriteLine(hd.Mahoadon);

            _shopthoitrang.SaveChanges();
            
            return "success";
        }
    }
}
