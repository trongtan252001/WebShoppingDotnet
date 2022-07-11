using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebShoppingDotnet.Helpers;
using WebShoppingDotnet.Models;
using WebShoppingDotnet.Views;

namespace WebShoppingDotnet.Controllers
{
    public class CollectionsController : Controller
    {
        private ShopthoitrangContext _shopthoitrang;

        public CollectionsController()
        {
            _shopthoitrang = new ShopthoitrangContext();
        }
        [Route("[controller]/{id?}")]
        [Route("[controller]/[action]/{id?}")]
        public async Task<IActionResult> Index(String? id, string sortOrder, int? pageNumber,String? rangePrice,String ?size)
        {

            var products = _shopthoitrang.Products
                            .Where(p => p.Trangthai == 1);
            var modelSort = new SortHelper();
            ViewBag.modelSort = modelSort;
            if (id == null)
            {
                ViewBag.title = "Products";

                products = _shopthoitrang.Products
                        .Where(p => p.Trangthai == 1);

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
                    ;
            }
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            switch (rangePrice)
            {
                case "0-300000":
                    products = products.Where(p=> ((p.Ngaybatdausale <=today&& today <= p.Ngayketthucsale&&(-p.Sale+1)*p.Dongia>0&& (-p.Sale+1) * p.Dongia <= 300000))|| ( p.Dongia > 0 &&p.Dongia <= 200000));
                    break;
                case "300000-500000":
                    products = products.Where(p => ((p.Ngaybatdausale <= today && today <= p.Ngayketthucsale && (-p.Sale + 1) * p.Dongia > 300000 && (-p.Sale + 1) * p.Dongia <= 500000)) || (p.Dongia > 300000 && p.Dongia <= 500000));

                    break;
                case "500000-700000":
                    products = products.Where(p => ((p.Ngaybatdausale <= today && today <= p.Ngayketthucsale && (-p.Sale + 1) * p.Dongia > 500000 && (-p.Sale + 1) * p.Dongia <= 700000)) || (p.Dongia > 500000 && p.Dongia <= 700000));
                    break;
                case "700000-1000000":
                    products = products.Where(p => ((p.Ngaybatdausale <= today && today <= p.Ngayketthucsale && (-p.Sale + 1) * p.Dongia > 700000 && (-p.Sale + 1) * p.Dongia <= 1000000)) || (p.Dongia > 700000 && p.Dongia <= 1000000));
                    break;
                case "1000000-1500000":
                    products = products.Where(p => ((p.Ngaybatdausale <= today && today <= p.Ngayketthucsale && (-p.Sale + 1) * p.Dongia > 1000000 && (-p.Sale + 1) * p.Dongia <= 1500000)) || (p.Dongia > 1000000 && p.Dongia <= 1500000));
                    break;
                case "1500000":
                    products = products.Where(p => ((p.Ngaybatdausale <= today && today <= p.Ngayketthucsale && (-p.Sale + 1) * p.Dongia > 1500000)) || (p.Dongia > 1500000));
                    break;
                default:
                    break;
            }
            ViewData["rangePrice"] = rangePrice;

            switch (size)
            {
                case "S":
                    products = products.Where(p=>p.S>0);
                    break;
                case "M":
                    products = products.Where(p => p.M > 0);
                    break;
                case "L":
                    products = products.Where(p => p.L > 0);
                    break;
                case "XL":
                    products = products.Where(p => p.Xl > 0);
                    break;
                default:
                    sortOrder = "all";
                    break;
            }
            ViewData["size"] = size;

            if (products == null)
            {
                return NotFound("Không thấy loai san pham");
            }

            switch (sortOrder)
            {
                case "name":
                    products = products.OrderBy(p => p.Tensp);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.Tensp);
                    break;

                case "price":
                    products = products.OrderBy(p => p.Dongia);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Dongia);
                    break;
                default:
                    sortOrder = "all";
                    break;
            }

            ViewData["CurrentSort"] = sortOrder;
            products = products.Include(p => p.Hinhanhs);
            var totalItems = await products.CountAsync();
            ViewData["TotalItems"] = totalItems;
            int pageSize = 12;
            ViewData["pageNumber"] = pageNumber??1;

            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }
}
