using System.Globalization;
using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.Services
{
    public class CartService
    {
        public List<CartDto> getListCart(String iduser)
        {
            List<CartDto> _cartDtoList = new List<CartDto>();
            ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();

            List<Giohang> _giohangList = _shopthoitrang.Giohangs.Where(g => g.Iduser == iduser).ToList();
            for (int i = 0; i < _giohangList.Count; i++)
            {
                Product p = _shopthoitrang.Products.First(p => p.Masp == _giohangList[i].Idsp);
                String urlImage = _shopthoitrang.Hinhanhs.First(h => h.Idsp == _giohangList[i].Idsp).Url;
                _cartDtoList.Add(new CartDto(_giohangList[i], p, urlImage));
            }

            return _cartDtoList;
        }
    }

    public class CartDto
    {
        public Giohang giohang { get; set; }
        public Product product { get; set; }
        public String urlImage { get; set; }


        public CartDto(Giohang giohang, Product product, String urlImage)
        {
            this.giohang = giohang;
            this.product = product;
            this.urlImage = urlImage;
        }

        public List<int> getSileList()
        {
            var list = new List<int>();
            list.Add(product.S);
            list.Add(product.M);
            list.Add(product.L);
            list.Add(product.Xl);

            return list;
        }

    }

    public class CheckoutDTo
    {
    public String id { get; set; }
    public String size { get; set; }
    public int quantity { get; set; }
    public String name { get; set; }
    public String img { get; set; }
    public float price { get; set; }
    public string ParseCurrencyVND(string input)
    {
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
        return double.Parse(input).ToString("#,###", cul.NumberFormat) + " đ";
    }


    }


}
