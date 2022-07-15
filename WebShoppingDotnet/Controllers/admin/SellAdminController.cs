using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebShoppingDotnet.Helpers;
using WebShoppingDotnet.Views;
namespace WebShoppingDotnet.Controllers.admin
{
    public class SellAdminController : Controller
    {
        private ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var products = _shopthoitrang.Products.Include(p => p.Hinhanhs).Where(p => p.Sale > 0);

            int pageSize = 16;
            var totalItems = await products.CountAsync();
            ViewData["TotalPage"] = totalItems % 16 == 0 ? totalItems / 16 : totalItems / 16 + 1;
            ViewData["page"] = pageNumber;
            ViewData["loaiSp"] = _shopthoitrang.Loaisps.ToList();
            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }
}
