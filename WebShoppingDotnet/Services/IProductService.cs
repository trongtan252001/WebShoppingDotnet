using System.Globalization;

namespace WebShoppingDotnet.Services
{
    public interface IProductService
    {
        string ParseCurrencyVND(float input);
    }
    public class ProductService :IProductService{
        public string ParseCurrencyVND(float input)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            return double.Parse(input + "").ToString("#,###", cul.NumberFormat) + " đ";
        }
}
}
