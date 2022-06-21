using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.Controllers
{
    public class ProductsController : Controller
    {
         private ShopthoitrangContext _shopthoitrang;

        public ProductsController()
        {
            _shopthoitrang = new ShopthoitrangContext();
        }
        [Route("[controller]/{id?}")]
        [Route("[controller]/[action]/{id?}")]
        public async Task<IActionResult> Index(String? id, string sortOrder)
        {
            
                IIncludableQueryable<Product, ICollection<Hinhanh>> products = null;
                ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["DateSortParm"] = sortOrder == "Price" ? "Price" : "Date";
                if (id==null)
                {
                    ViewBag.title = "Products";

                    products = _shopthoitrang.Products
                            .Where(p => p.Trangthai == 1)
                            .Include(p => p.Hinhanhs);

                }
                else
                {

                Loaisp loaisp = _shopthoitrang.Loaisps.FirstOrDefault(l => l.Idloai == id);
                    if (loaisp == null)
                    {
                        return NotFound("Không có loại sản phẩm");
                    }
                    ViewBag.title = loaisp.NameLoai;

                products = _shopthoitrang.Products
                        .Where(p => p.Trangthai == 1 && p.Loaisp == id)
                        .Include(p => p.Hinhanhs);
            }
                
                if (products == null)
                {
                    return NotFound("Không thấy loai san pham");
                }
                IOrderedQueryable<Product> productsSort;
                switch (sortOrder)
                {
                    case "name_desc":
                        productsSort = products.OrderByDescending(p=>p.Tensp);
                        break;
                    case "Price":
                        productsSort = products.OrderBy(p => p.Dongia);
                        break;
                    case "price_desc":
                        productsSort = products.OrderByDescending(p => p.Dongia);
                        break;
                    default:
                        productsSort = products.OrderBy(p => p.Tensp);

                    break;
                }


            return View(await productsSort.AsNoTracking().ToListAsync());
        }
    }
}
