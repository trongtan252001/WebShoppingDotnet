using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.common
{
    public class DetailOrderClient
    {
        public Cthoadon ct { get; set; } = null!;
        public string urlImg { get; set; }
        public string name { get; set; }

        public DetailOrderClient(Cthoadon ct, string urlImg, string name)
        {
            this.ct = ct;
            this.urlImg = urlImg;
            this.name = name;
        }
    }
}
