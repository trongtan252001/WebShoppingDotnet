
using WebShoppingDotnet.common;
using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.Services
{
    public class IOrderService
    {
        static ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
        public static int getSumBillUser(String idUser, String status)
        {
            int total = 0;
            if (status.Equals("all"))
                total = _shopthoitrang.Hoadons.Count(b => b.Iduser.Equals(idUser));
            else total = _shopthoitrang.Hoadons.Count(b => b.Iduser.Equals(idUser) && b.TrangThai == (Int32.Parse(status)));
            return total;
        }
        public static Order getBill(String idOrder)
        {
            Order order = new Order();
            Hoadon hoaDon = _shopthoitrang.Hoadons.FirstOrDefault(b => b.Mahoadon.Equals(idOrder));
            if (hoaDon != null)
            {
                User user = _shopthoitrang.Users.FirstOrDefault(u => u.Id.Equals(hoaDon.Iduser));
                Khachhang khachHang = _shopthoitrang.Khachhangs.FirstOrDefault(c => c.Iduser.Equals(hoaDon.Iduser));
                order.getOrder(hoaDon, khachHang, user);
            }

            return order;
        }
        public static List<Cthoadon> getCTHoaDon(String idBill)
        {
            return new List<Cthoadon>();
        }
        public static List<Order> getBillUser(int limit, int skip, String idUser, String status)
        {
            List<Hoadon> hoadons = new List<Hoadon>();
            if (status.Equals("all"))
            {
                hoadons = _shopthoitrang.Hoadons.Where(h => h.Iduser.Equals(idUser)).OrderBy(h => h.NgayDatHang).Skip(skip).Take(limit).ToList();


            }

            else
                hoadons = _shopthoitrang.Hoadons.Where(h => h.Iduser.Equals(idUser) && h.TrangThai == (Int32.Parse(status))).OrderBy(h => h.NgayDatHang).Skip(skip).Take(limit).ToList();
            User user = _shopthoitrang.Users.FirstOrDefault(u => u.Id.Equals(idUser));
            Khachhang khachHang = _shopthoitrang.Khachhangs.FirstOrDefault(c => c.Iduser.Equals(idUser));
            List<Order> orders = new List<Order>();
            for (int i = 0; i < hoadons.Count; i++)
            {
                Order order = new Order();
                order.getOrder(hoadons.ElementAt(i), khachHang, user);
                orders.Add(order);
            }
            return orders;
        }
        public static int cancelOrder(string orderID)
        {

            Hoadon hoadon = _shopthoitrang.Hoadons.FirstOrDefault(h => h.Mahoadon.Equals(orderID));

            hoadon.TrangThai = 1;

            return _shopthoitrang.SaveChanges();
        }
        public static List<DetailOrderClient> getDetail(string orderID)
        {

            /*d*/
            List<Cthoadon> list = _shopthoitrang.Cthoadons.Where(d => d.MaHd.Equals(orderID)).ToList();
            List<DetailOrderClient> orders = new List<DetailOrderClient>();
            for (int i = 0; i < list.Count; i++)
            {
                Product p = _shopthoitrang.Products.FirstOrDefault(p => p.Masp.Equals(list.ElementAt(i).MaSp));
                string hinhanh = _shopthoitrang.Hinhanhs.OrderBy(i => i.Url).FirstOrDefault(i => i.Idsp.Equals(p.Masp)).Url;
                DetailOrderClient dod = new DetailOrderClient(list.ElementAt(i), hinhanh, p.Tensp);
                orders.Add(dod);
            }
           
            return orders;

        }
        public static int receive(string orderID)
        {
            Hoadon hoadon = _shopthoitrang.Hoadons.FirstOrDefault(h => h.Mahoadon.Equals(orderID));
            hoadon.NgayNhanHang = DateTime.Now;
            return _shopthoitrang.SaveChanges();
        }
    }
}
