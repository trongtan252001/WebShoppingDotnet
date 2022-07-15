using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebShoppingDotnet.common;
using WebShoppingDotnet.Models;
using WebShoppingDotnet.Services;

namespace WebShoppingDotnet.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index(String status)
        {
            String idUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user")).Id;
            System.Diagnostics.Debug.WriteLine("id user" + idUser);
            System.Diagnostics.Debug.WriteLine("status" + status);
            int count=IOrderService.getSumBillUser(idUser,status);
            List<Order> orders = IOrderService.getBillUser(4, 0, idUser, status);
            int page = count % 4 == 0 ? count / 4:count / 4 + 1;
            ViewBag.page=page;
            ViewBag.orders=orders;
            ViewBag.status=status;
            return View();
        }
        public ActionResult Redirect(string page, string status)
        {
            string idUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user")).Id;
            int count = IOrderService.getSumBillUser(idUser, status);
            List<Order> orders = IOrderService.getBillUser(4, 4*(Int32.Parse(page)-1), idUser, status);
            ViewBag.page = page;
            ViewBag.orders = orders;
            ViewBag.status = status;
            string jsonList=JsonConvert.SerializeObject(orders);
            return Content(jsonList);
           
        }
        public IActionResult Handle (string orderID,int status)
        {
            int affect=0;
            /*yeu cau huy*/
            if (status == 0)
            {
                affect = IOrderService.cancelOrder(orderID);
            }
            else if (status == 1)
            {
                affect = IOrderService.receive(orderID);
            }
            if (affect == 0) return Content("fail");
            else return Content("success");
        }
        public IActionResult Detail(string orderID)
        {
            List<DetailOrderClient> list=IOrderService.getDetail(orderID);
            string jsonList= JsonConvert.SerializeObject(list);
            return Content(jsonList);
        }
    }
}
