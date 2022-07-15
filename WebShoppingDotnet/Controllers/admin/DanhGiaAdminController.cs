using Microsoft.AspNetCore.Mvc;

namespace WebShoppingDotnet.Controllers.admin
{
    public class DanhGiaAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
