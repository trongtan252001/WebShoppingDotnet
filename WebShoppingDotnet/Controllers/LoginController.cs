using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            User user = IUserService.checkLogin(userName, pass);
            
            if (user != null)
            {
                Khachhang khachhang=IUserService.getKhachHang(user.Id);
                string jsonUser = JsonConvert.SerializeObject(user);
                /*System.Diagnostics.Debug.WriteLine(jsonUser);*/
                HttpContext.Session.SetString("user", jsonUser);
                
                return RedirectToAction("Index", "Home");
            }
            ViewBag.userName = userName;
            
            return View("Index");
        }
    }
}
