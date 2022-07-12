using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.common;
using WebShoppingDotnet.Models;
using WebShoppingDotnet.Service;

namespace WebShoppingDotnet.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index(string idUser)
        {
            User user = IUserService.getUser(idUser);
            ViewBag.user=user;
            Khachhang khachHang=IUserService.getKhachHang(idUser);
            ViewBag.khachHang=khachHang;
            return View();
        }
        [HttpPost]
        public IActionResult Update(InfoUser infoUser)
        {

        }
    }
}
