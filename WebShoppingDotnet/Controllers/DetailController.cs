using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index(string idProduct)
        {
            ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
            Product? product = _shopthoitrang.Products.FirstOrDefault(p => p.Masp.Equals(idProduct));
            Bosutap? collection = _shopthoitrang.Bosutaps.FirstOrDefault(c => c.IdBst.Equals(product.IdboSuuTap));
            List<Product> products = _shopthoitrang.Products.Where(l => l.Loaisp.Equals(product.Loaisp)).Take(6).ToList();
            List<String> urls = _shopthoitrang.Hinhanhs.Where(i => i.Idsp.Equals(product.Masp)).OrderByDescending(i => i.Url).Select(i => i.Url).ToList();
            Dictionary<String, List<String>> map = new Dictionary<String, List<String>>();
            foreach (var p in products)
            {
                List<String> urlsOfProduct = _shopthoitrang.Hinhanhs.Where(i => i.Idsp.Equals(p.Masp)).OrderByDescending(i => i.Url).Select(i => i.Url).ToList();

                map.Add(p.Masp, urlsOfProduct);
            }
            System.Diagnostics.Debug.WriteLine(products.Count);
            ViewBag.Product = product;
            ViewBag.Collection = collection;
            ViewBag.Products = products;
            ViewBag.Urls = urls;
            ViewBag.Map = map;
            return View();
        }
    }
}
