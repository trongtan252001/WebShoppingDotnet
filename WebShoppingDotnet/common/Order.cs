namespace WebShoppingDotnet.common
{
    public class Order
    {



        public string orderId { get; set; } 
        public string userId { get; set; }
        public DateTime? orderDate { get; set; }
        // 0 chờ xác nhận, 1 đã hủy , 2 đã xác nhận, 3 đang giao hàng, 4 đã giao hàng
        public int status { get; set; } 
        public DateTime? ngayNhanHang { get; set; }
        public int? soNgayDuKien { get; set; }
        public double totalPrice { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string tinhTP { get; set; }
        public string quanHuyen { get; set; }
        public string phuongXa { get; set; }

        public Order(string orderId, string userId, DateTime? orderDate, int status, DateTime? ngayNhanHang, int? soNgayDuKien, double totalPrice, string email, string name, string phone, string address, string tinhTP, string quanHuyen, string phuongXa)
        {
            this.orderId = orderId;
            this.userId = userId;
            this.orderDate = orderDate;
            this.status = status;
            this.ngayNhanHang = ngayNhanHang;
            this.soNgayDuKien = soNgayDuKien;
            this.totalPrice = totalPrice;
            this.email = email;
            this.name = name;
            this.phone = phone;
            this.address = address;
            this.tinhTP = tinhTP;
            this.quanHuyen = quanHuyen;
            this.phuongXa = phuongXa;
        }

        public Order()
        {
        }
    }
}
