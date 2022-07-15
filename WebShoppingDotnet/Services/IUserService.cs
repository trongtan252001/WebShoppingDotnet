using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using WebShoppingDotnet.common;
using WebShoppingDotnet.Models;
using System.Net;
using System.Net.Mail;

namespace WebShoppingDotnet.Service
{
    public static class IUserService
    {
        static ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
        public static User checkLogin(string username, string pass)
        {

            pass = ComputeSha512Hash(pass);
            User user = _shopthoitrang.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Userpassword.Equals(pass));
            if (user.Isvirification == 0)
                return user;
            else return null;

        }
        public static User getUser(string idUser)
        {
            return _shopthoitrang.Users.FirstOrDefault(u => u.Id.Equals(idUser));
        }
        public static Khachhang getKhachHang(string idUser)
        {

            return _shopthoitrang.Khachhangs.FirstOrDefault(c => c.Iduser.Equals(idUser));
        }
        public static int getCountCart(string idUser)
        {
            return _shopthoitrang.Giohangs.Count(c => c.Iduser.Equals(idUser));
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
            User user = _shopthoitrang.Users.FirstOrDefault(u => u.Id.Equals(infoUser.id));
            Khachhang khachHang = getKhachHang(user.Id);
            if (khachHang == null)
            {
                khachHang = new Khachhang();
                khachHang.Iduser = user.Id;
                khachHang.HoTen = infoUser.name;
                khachHang.TinhTp = infoUser.tinhTP;
                khachHang.QuanHuyen = infoUser.quanHuyen;
                khachHang.PhuongXa = infoUser.phuongXa;
                khachHang.DiaChi = infoUser.address;
                khachHang.DienThoai = infoUser.phone;

                return createCustomer(khachHang);
            }
            else if (user != null && khachHang != null)
            {
                khachHang.HoTen = infoUser.name;
                khachHang.TinhTp = infoUser.tinhTP;
                khachHang.QuanHuyen = infoUser.quanHuyen;
                khachHang.PhuongXa = infoUser.phuongXa;
                khachHang.DiaChi = infoUser.address;
                user.Usermail = infoUser.email;
                khachHang.DienThoai = infoUser.phone;

            }
            int affect = _shopthoitrang.SaveChanges();
            if (affect > 0) return true;
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
        public static bool checkAccountInfo(string userName, string userMail)
        {
            int record = _shopthoitrang.Users.Count(u => u.Username.Equals(userName) || u.Usermail.Equals(userMail));
            if (record > 0) return false;
            else return true;
        }
        public static bool insertUser(string username, string password, string mail, string vetificationCode, string idUser)
        {
            User user = new User(idUser, username, password, mail, 1, vetificationCode, DateTime.Now.Millisecond, 1);
            _shopthoitrang.Users.Add(user);
            int affect = _shopthoitrang.SaveChanges();
            if (affect == 1) return true;
            else return false;
        }
        public static bool checkVerification(string userName, string vetificationCode)
        {
            User user = _shopthoitrang.Users.FirstOrDefault(u => u.Username.Equals(userName) && u.Vericaioncode.Equals(vetificationCode));
            if (user.Isvirification == 1)
                user.Isvirification = 0;
            return true;

        }
        public static bool verify(string code)
        {
            User user = _shopthoitrang.Users.FirstOrDefault(u => u.Vericaioncode.Equals(code));
            user.Isvirification = 0;
            int affect=_shopthoitrang.SaveChanges();
            if (affect == 1) return true;
            return false;

        }
        public static void SendMail(MailInfor mail)
        {
            if (mail != null)
            {
                System.Diagnostics.Debug.WriteLine("Gui mail nao 2");
                var mailObj = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("19130249@st.hcmuaf.edu.vn", "ehpcobexozfujnll")
                };

                
                var message = new MailMessage();
                message.From = new MailAddress(mail.Src,"Nguoi gui");
                message.ReplyToList.Add(mail.Src);
                message.To.Add(new MailAddress(mail.Dest,"Nguoi nhan"));
                message.Subject = mail.Subject;
                message.Body = mail.Body;
                mailObj.Send(message);


            }


        }
    }
}
