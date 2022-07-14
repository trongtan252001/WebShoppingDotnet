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
            if(status.Equals("all"))
                _shopthoitrang.Hoadons.Count(b => b.Iduser.Equals(idUser));
            total = _shopthoitrang.Hoadons.Count(b => b.Iduser.Equals(idUser) && b.TrangThai.Equals(status));
            return total;
        }
        public static Order getBill(String idOrder)
        {
            Order order = new Order();
            Hoadon hoaDon=_shopthoitrang.Hoadons.FirstOrDefault(b=>b.Mahoadon.Equals(idOrder));
            if(hoaDon != null)
            {
                User user = _shopthoitrang.Users.FirstOrDefault(u => u.Id.Equals(hoaDon.Iduser));
                Khachhang khachHang = _shopthoitrang.Khachhangs.FirstOrDefault(c => c.Iduser.Equals(hoaDon.Iduser));
                order = new Order(hoaDon.Mahoadon, hoaDon.Iduser, hoaDon.NgayDatHang, hoaDon.TrangThai, hoaDon.NgayNhanHang,
                    hoaDon.SoNgayDuKien, hoaDon.TongTien, user.Usermail, khachHang.HoTen, khachHang.DienThoai, khachHang.DiaChi, khachHang.TinhTp
                    , khachHang.QuanHuyen, khachHang.PhuongXa);
            }
            
            return order;
        }
        public static List<Cthoadon> getCTHoaDon(String idBill)
        {
            return new List<Cthoadon>();
        }
        public static List<Order> getBillUser(int limit, int start, String idUser, String status)
        {
            List<Hoadon> hoadons=_shopthoitrang.Hoadons.Where(h => h.Iduser.Equals(idUser)).ToList();
            List<Order> orders = new List<Order>();
            return null;
        }

    }
}
