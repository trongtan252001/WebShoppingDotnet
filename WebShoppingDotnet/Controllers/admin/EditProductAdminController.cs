using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.Controllers.admin
{
    public class EditProductAdminController : Controller
    {
        ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();

        public IActionResult Index(string m)
        {
            var type = _shopthoitrang.Loaisps.ToList();
            var bst = _shopthoitrang.Bosutaps.ToList();
            ViewData["maso"] = m;
            ViewData["type"] = type;
            ViewData["bst"] = bst;
            var product = _shopthoitrang.Products.Single(p => p.Masp.Equals(m));
            ViewData["hinhanh"] = _shopthoitrang.Hinhanhs.Where(h => h.Idsp.Equals(m)).ToList();
            return View(product);
        }
        [HttpPost]
        public String EditProduct(string? product_name, string? product_quantity_s, string? product_quantity_l,
           string? product_quantity_m, string? product_quantity_xl, string? product_type, string? product_colection,
           string? product_color, string? product_description, string? product_status, string? product_price,
           string? product_price_sale, string? product_date_start, string? product_date_end,
           string m
           )
        {
            var product = _shopthoitrang.Products.Where(p => p.Masp.Equals(m)).First();
            product.Tensp = product_name;
            product.S = Int32.Parse(product_quantity_s);
            product.L = Int32.Parse(product_quantity_l);
            product.M = Int32.Parse(product_quantity_m);
            product.Xl = Int32.Parse(product_quantity_xl);
            product.Loaisp = product_type;
            product.IdboSuuTap = product_colection;
            product.Mau = product_color;
            product.Mota = product_description;
            product.Trangthai = Int32.Parse(product_status);
            product.Dongia = float.Parse(product_price);
            product.Sale = float.Parse(product_price_sale);
            if (product_date_start != null)
                product.Ngaybatdausale = DateOnly.Parse(product_date_start);
            if (product_date_end != null)
                product.Ngayketthucsale = DateOnly.Parse(product_date_end);
            _shopthoitrang.SaveChanges();


            return "success";
        }
    }
}
