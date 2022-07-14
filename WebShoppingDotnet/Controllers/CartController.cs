using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using WebShoppingDotnet.Models;
using WebShoppingDotnet.Services;

namespace WebShoppingDotnet.Controllers
{
    public class CartController : Controller
    {
        public const string CARTKEY = "cart";
        CartService cartService = new CartService();
        public IActionResult Index()
        {
            String jsonUser = HttpContext.Session.GetString("user");
            List<CartDto> _cartDtoList = new List<CartDto>();

            if (jsonUser == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                User user = JsonConvert.DeserializeObject<User>(jsonUser);
                ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
                _cartDtoList = cartService.getListCart(user.Id);
            }
           
            return View(_cartDtoList);
        }
        [HttpPost]
        public JsonResult AddCart(String? id,String? size)
        {
            String jsonUser = HttpContext.Session.GetString("user");
            int quantity = 0;

            if (jsonUser == null)
            {
                
                 return Json(new
                 {
                     success=false,
                     redirectUrl = Url.Action("Index", "Login"),
                     isRedirect = true
                 });
            }
            else
            {
                ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
                User user = JsonConvert.DeserializeObject<User>(jsonUser);
                String[] sizeStrings = JsonConvert.DeserializeObject<String[]>(size);

                for (int i = 0; i < sizeStrings.Length; i++)
                {
                    var cartitem = _shopthoitrang.Giohangs.FirstOrDefault(item => item.Iduser==user.Id && item.Idsp==id&& item.Size==sizeStrings[i]);
                    if (cartitem != null)
                    {
                        cartitem.Soluong = cartitem.Soluong + 1;
                        _shopthoitrang.SaveChanges();
                    }
                    else
                    {
                        //  Thêm mới
                        String idCart = id + sizeStrings[i];
                        Giohang cart = new Giohang(){ Idsp = id,Iduser = user.Id, Soluong = 1, Size = sizeStrings[i] };
                        _shopthoitrang.Giohangs.Add(cart);
                        _shopthoitrang.SaveChanges();
                    }
                }
                quantity = (int)_shopthoitrang.Giohangs.Where(item => item.Iduser == user.Id).Sum(i => i.Soluong);
            }

            return Json(new {
                success = true,
                quantity = quantity
            });
        }
        [HttpPost]
        public JsonResult UpdateCart(String? id, String? size,int? quantity)
        {
            String jsonUser = HttpContext.Session.GetString("user");

            if (jsonUser == null||size == null || id == null || quantity == null)
            {
                //send error ajax json
                return Json(new
                {
                    status = "error",
                    quantity = 0,
                });
            }
            // Cập nhật Cart thay đổi số lượng quantity ...
            ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
            User user = JsonConvert.DeserializeObject<User>(jsonUser);
            var cartitem = _shopthoitrang.Giohangs.FirstOrDefault(item => item.Iduser == user.Id && item.Idsp== id && item.Size==size);

            if (cartitem != null)
            {
                Product p = _shopthoitrang.Products.First(p => p.Masp == cartitem.Idsp);
                if (cartitem.Soluong+ quantity> p.GetSize(size))
                {
                    cartitem.Soluong = p.GetSize(size);
                    _shopthoitrang.SaveChanges();
                    return Json(new
                    {
                        status = "outsize",
                        quantity = cartitem.Soluong,
                    });
                }
                else
                {

                    cartitem.Soluong = quantity;
                    _shopthoitrang.SaveChanges();
                    return Json(new
                    {
                        status = "success",
                        quantity = quantity,
                    });
                }
            }

            return Json(new
            {
                status = "error",
                quantity = 0,
            });
        }
        [HttpPost]
        public String remoteCart(String? id,String? size)
        {
            String jsonUser = HttpContext.Session.GetString("user");

            if (jsonUser == null|| id == null)
            {
                //send error ajax json
                return "error";
            }
            // Cập nhật Cart thay đổi số lượng quantity ...
            ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
            User user = JsonConvert.DeserializeObject<User>(jsonUser);
            var cartitem = _shopthoitrang.Giohangs.FirstOrDefault(item => item.Iduser == user.Id && item.Idsp == id && item.Size == size);
            var gioHang = _shopthoitrang.Giohangs.FirstOrDefault(item =>
                item.Iduser == user.Id && item.Idsp == id && item.Size == size);
            _shopthoitrang.Giohangs.Remove(gioHang);
            _shopthoitrang.SaveChanges();
            return "success";
        }

    }
}
