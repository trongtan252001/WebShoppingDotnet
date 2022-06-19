using Microsoft.EntityFrameworkCore;
using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.Services
{
    public interface IHomeService
    {
        ICollection<Product> GetFeaturedProducts(int limit);
    }
    public class HomeServices:IHomeService{
        public ICollection<Product> GetFeaturedProducts(int limit)
        {
            ShopthoitrangContext context = new ShopthoitrangContext();
            return context.Products.Where(s=>s.Trangthai == 1)
                .OrderBy(x => x.Dongia)
                .Include(x => x.Hinhanhs)
                .Take(limit).ToList();
        }
    }
}
