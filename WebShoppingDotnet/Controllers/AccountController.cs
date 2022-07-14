using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebShoppingDotnet.common;
using WebShoppingDotnet.Models;
using WebShoppingDotnet.Service;

namespace WebShoppingDotnet.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            string jsonUser = HttpContext.Session.GetString("user");
            System.Diagnostics.Debug.WriteLine(jsonUser);
            if (jsonUser != null)
            {
                ViewBag.User = jsonUser;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update(InfoUser infoUser)
        {
            if(IUserService.updateInfo(infoUser))
               return Content("success");
            else return Content("fail");
        }
    }
}
