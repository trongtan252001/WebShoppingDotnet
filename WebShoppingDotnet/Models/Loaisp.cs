using System;
using System.Collections.Generic;

namespace WebShoppingDotnet.Models
{
    public partial class Loaisp
    {
        public Loaisp()
        {
            Products = new HashSet<Product>();
        }

        public string Idloai { get; set; } = null!;
        public string NameLoai { get; set; } = null!;
        public string? Motatheloai { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
