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
        public static bool updateInfo(InfoUser infoUser)
        {
            User user= _shopthoitrang.Giohangs.Count(c => c.Iduser.Equals(infoUser.));
            Khachhang khachHang = getKhachHang(user.Id);
            return true;
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
