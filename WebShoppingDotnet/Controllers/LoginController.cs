using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.Models;
using WebShoppingDotnet.Service;

namespace WebShoppingDotnet.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string userName, string pass)
        {
            User user = UserService.checkLogin(userName, pass);
            
            if (user != null)
            {
                Khachhang khachhang=UserService.getKhachHang(user.Id);
                HttpContext.Session.SetString("user", user.Id);
               
                return RedirectToAction("Index", "Home");
            }
            ViewBag.userName = userName;
            
            return View("Index");
        }
    }
}
