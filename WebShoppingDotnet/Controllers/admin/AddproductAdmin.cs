using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebShoppingDotnet.Helpers;
using WebShoppingDotnet.Views;
namespace WebShoppingDotnet.Controllers.admin
{
    public class AddproductAdmin : Controller
    {
        private ShopthoitrangContext _shopthoitrang;

        public AddproductAdmin()
        {
            _shopthoitrang = new ShopthoitrangContext();
        }
        public IActionResult Index()
        {
            var type = _shopthoitrang.Loaisps.ToList();
            var bst = _shopthoitrang.Bosutaps.ToList();
            ViewData["type"] = type;
            ViewData["bst"] = bst;
            return View();
        }
        [HttpPost]
        public String AddProduct(string? product_name,string? product_quantity_s, string? product_quantity_l,
            string? product_quantity_m, string? product_quantity_xl, string? product_type, string? product_colection,
            string? product_color, string? product_description, string? product_status, string? product_price,
            string? product_price_sale, string? product_date_start, string? product_date_end
            )
        {
            var product = new Product();
            Guid g = Guid.NewGuid();
            product.Masp = g.ToString();
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
            DateTime now = DateTime.Now;
            Console.WriteLine(now.Month + "/" + now.Day  + "/" + now.Year);
            String t = now.Month + "/" + now.Day + "/" + now.Year;
            DateOnly dateOnly = DateOnly.Parse(t);
            product.Ngaynhap = dateOnly;
            if (product_date_start != null)
                product.Ngaybatdausale = DateOnly.Parse(product_date_start);
            if (product_date_end != null) 
            product.Ngayketthucsale = DateOnly.Parse(product_date_end);
            //Console.WriteLine("product_quantity_l: "+ product_quantity_l);
            //Console.WriteLine("product_quantity_m: " + product_quantity_m);
            //Console.WriteLine("product_quantity_xl: "+ product_quantity_xl);
            //Console.WriteLine("product_type: " + product_type);
            //Console.WriteLine("product_colection: "  + product_colection);
            //Console.WriteLine("product_color: " + product_color);
            //Console.WriteLine("product_description: " + product_description);
            //Console.WriteLine("product_description: " + product_description);
            //Console.WriteLine("product_status: " + product_status);
            //Console.WriteLine("product_price: " + product_price);
            //Console.WriteLine("product_price_sale: " + product_price_sale);
            //Console.WriteLine("product_date_start: " + product_date_start);
            //Console.WriteLine("product_date_end: " + product_date_end);
            //D31182
            for (var i = 1;i < 4;i++)
            {
                var hinhAnh = new Hinhanh();
                Guid g2 = Guid.NewGuid();
                hinhAnh.Idhinhanh = g2.ToString();
                hinhAnh.Idsp = g.ToString();
                hinhAnh.Url = "/img/product/108_" + i + ".jpg";
                _shopthoitrang.Hinhanhs.Add(hinhAnh);

            }
            var resuklt = _shopthoitrang.Products.Add(product);
            _shopthoitrang.SaveChanges();

            return "success";
        }
    }
}
