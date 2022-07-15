using System.Security.Cryptography;
using System.Text;
using WebShoppingDotnet.common;
using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.Service
{
    public static class IUserService
    {
        static ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
        public static User checkLogin(string username, string pass)
        {
            
            pass = ComputeSha512Hash(pass);
            User user = _shopthoitrang.Users.FirstOrDefault(u=>u.Username.Equals(username) && u.Userpassword.Equals(pass));
            return user;
        }
        public static User getUser(string idUser)
        {
            return _shopthoitrang.Users.FirstOrDefault(u=>u.Id.Equals(idUser));
        }
        public static Khachhang getKhachHang(string idUser)
        {
            
            return _shopthoitrang.Khachhangs.FirstOrDefault(c=>c.Iduser.Equals(idUser));
        }
        public static int getCountCart(string idUser)
        {
           return  _shopthoitrang.Giohangs.Count(c=>c.Iduser.Equals(idUser));
        }
        public static int getCountNotify(string idUser)
        {
            return 1;
        }
        public static bool createCustomer(Khachhang kh)
        {
           _shopthoitrang.Khachhangs.Add(kh);
            if (_shopthoitrang.SaveChanges() > 0) return true;
            else return false;
        }
        public static bool updateInfo(InfoUser infoUser)
        {
        User user= _shopthoitrang.Users.FirstOrDefault(u=>u.Id.Equals(infoUser.id));
            Khachhang khachHang = getKhachHang(user.Id);
            if(khachHang == null)
            {
                khachHang=new Khachhang();
                khachHang.Iduser = user.Id;
                khachHang.HoTen = infoUser.name;
                khachHang.TinhTp = infoUser.tinhTP;
                khachHang.QuanHuyen = infoUser.quanHuyen;
                khachHang.PhuongXa = infoUser.phuongXa;
                khachHang.DiaChi = infoUser.address;
                khachHang.DienThoai = infoUser.phone;

                return createCustomer(khachHang);
            }
            else if(user!=null && khachHang != null)
            {
                khachHang.HoTen = infoUser.name;
                khachHang.TinhTp = infoUser.tinhTP;
                khachHang.QuanHuyen=infoUser.quanHuyen;
                khachHang.PhuongXa=infoUser.phuongXa;
                khachHang.DiaChi = infoUser.address;
                user.Usermail = infoUser.email;
                khachHang.DienThoai = infoUser.phone;
                
            }
            int affect = _shopthoitrang.SaveChanges();
            if(affect > 0) return true;
            return false;
        }
        public static string ComputeSha512Hash(string rawData)
        {
            StringBuilder builder = new StringBuilder();
            // Create a SHA256   
            using (SHA512 sha512Hash = SHA512.Create())
            {
                // ComputeHash - returns byte array  
                
                byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
