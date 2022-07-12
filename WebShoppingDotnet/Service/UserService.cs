using System.Security.Cryptography;
using System.Text;
using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.Service
{
    public static class UserService
    {
        public static User checkLogin(string username, string pass)
        {
            ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();
            pass = ComputeSha512Hash(pass);
            User user = _shopthoitrang.Users.FirstOrDefault(u=>u.Username.Equals(username) && u.Userpassword.Equals(pass));
            return user;
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
