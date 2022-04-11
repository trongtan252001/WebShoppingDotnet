using System;
using System.Collections.Generic;

namespace WebShoppingDotnet.Models
{
    public partial class Cthoadon
    {
        public string MaHd { get; set; } = null!;
        public float Price { get; set; }
        public int SoLuong { get; set; }
        public string MaSp { get; set; } = null!;
        public string? Size { get; set; }

        public virtual Hoadon MaHdNavigation { get; set; } = null!;
        public virtual Product MaSpNavigation { get; set; } = null!;
    }
}
