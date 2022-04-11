using System;
using System.Collections.Generic;

namespace WebShoppingDotnet.Models
{
    public partial class Giohang
    {
        public int Id { get; set; }
        public string Iduser { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string Idsp { get; set; } = null!;
        public int? Soluong { get; set; }

        public virtual Product IdspNavigation { get; set; } = null!;
        public virtual User IduserNavigation { get; set; } = null!;
    }
}
