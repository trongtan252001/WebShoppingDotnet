using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebShoppingDotnet.Helpers;
using WebShoppingDotnet.Views;
namespace WebShoppingDotnet.Controllers.admin
{
    public class ProductAdminController : Controller
    {
        private ShopthoitrangContext _shopthoitrang;

        public ProductAdminController()
        {
            _shopthoitrang = new ShopthoitrangContext();
        }
        public async Task<IActionResult> Index(int? pageNumber,int? status ,string? l,string n)
        {
           
            var products = _shopthoitrang.Products.Include(p => p.Hinhanhs).Where(p => 1 == 1);

            if ((status + "").Length > 0 && status != -1)
            {
                products = products.Where(p => p.Trangthai == status);
            }
            if ((l+"").Length > 0)
            {
                products = products.Where(p => p.Loaisp.Equals(l));
            }
           
            if ((n + "").Length > 0)
            {
                DateOnly dateOnly = DateOnly.Parse(n);
                products = products.Where(p => p.Ngaynhap == dateOnly);
            }

            int pageSize = 16;
            var totalItems = await products.CountAsync();
            ViewData["TotalPage"] = totalItems%16 == 0? totalItems / 16: totalItems / 16+1;
            ViewData["page"] = pageNumber;
            ViewData["loaiSp"] = _shopthoitrang.Loaisps.ToList();
            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        [HttpPost]
        public String EditProduct( string m)
        {
            var product = _shopthoitrang.Products.Where(p => p.Masp.Equals(m)).First();
            product.Trangthai = 2;
            _shopthoitrang.SaveChanges();
            return "success";
        }
        }
}
