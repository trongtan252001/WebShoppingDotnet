using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.Controllers
{
    public class CartController : Controller
    {
        public const string CARTKEY = "cart";

        public IActionResult Index()
        {
            ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
            List <Giohang> _giohangList = new List<Giohang>();
            Product p = new Giohang().IdspNavigation;
            return View(p);
        }
        [HttpPost]
        public JsonResult AddCart(String? id,String? size)
        {

            String[] sizeStrings = JsonConvert.DeserializeObject<String[]>(size);
            int? quantity = 0;

            var userText = HttpContext.Session.GetString("User");
             // Xử lý đưa vào Cart ...
             var cart = GetCartItems();
             for (int i = 0; i < sizeStrings.Length; i++)
             {
                var cartitem = cart.Find(p => p.Idsp==id&&p.Size== sizeStrings[i]);
                if (cartitem != null)
                {
                    // Đã tồn tại, tăng thêm 1
                    cartitem.Soluong++;
                }
                else
                {
                    //  Thêm mới
                    cart.Add(new Giohang() {Idsp = id,Soluong = 1,Size = sizeStrings[i]});
                }
            }
             quantity = cart.Sum(item=>item.Soluong);
             // Lưu cart vào Session
            SaveCartSession(cart);

            return Json("{\"quantity\":\""+ quantity + "\",\"success\":\"true\"}");
        }
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }
        void SaveCartSession(List<Giohang> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
        List<Giohang> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<Giohang>>(jsoncart);
            }
            else
            {
                return new List<Giohang>();
            }
        }
        
    }
}
