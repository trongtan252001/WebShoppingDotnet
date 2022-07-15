using System;
using System.Collections.Generic;

namespace WebShoppingDotnet.Models
{
    public partial class User
    {
        public User()
        {
            Giohangs = new HashSet<Giohang>();
            Hoadons = new HashSet<Hoadon>();
            Nhanxets = new HashSet<Nhanxet>();
        }

        public User(string id, string username, string userpassword, string? usermail, int role, string? vericaioncode, long? dateregister, int isvirification)
        {
            Id = id;
            Username = username;
            Userpassword = userpassword;
            Usermail = usermail;
            Role = role;
            Vericaioncode = vericaioncode;
            Dateregister = dateregister;
            Isvirification = isvirification;
        }

        public string Id { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Userpassword { get; set; } = null!;
        public string? Usermail { get; set; }
        public int Role { get; set; }
        public string? Vericaioncode { get; set; }
        public long? Dateregister { get; set; }
        public int Isvirification { get; set; }

        public virtual Khachhang Khachhang { get; set; } = null!;
        public virtual ICollection<Giohang> Giohangs { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
        public virtual ICollection<Nhanxet> Nhanxets { get; set; }
    }
}
