using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.Services
{
    public class CartService
    {
        
    }

    public class CartDto
    {
        private Giohang giohang { get; set; }
        private Product product { get; set; }

        public CartDto(Giohang giohang, Product product)
        {
            this.giohang = giohang;
            this.product = product;
        }
    }

}
