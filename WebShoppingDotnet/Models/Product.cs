using System;
using System.Collections.Generic;

namespace WebShoppingDotnet.Models
{
    public partial class Product
    {
        public Product()
        {
            Giohangs = new HashSet<Giohang>();
        }

        public string Masp { get; set; } = null!;
        public string Tensp { get; set; } = null!;
        public string IdboSuuTap { get; set; } = null!;
        public string? Mota { get; set; }
        public float Dongia { get; set; }
        public float Sale { get; set; }
        public string Mau { get; set; } = null!;
        public DateOnly Ngaynhap { get; set; }
        public DateOnly? Ngaybatdausale { get; set; }
        public DateOnly? Ngayketthucsale { get; set; }
        public string Loaisp { get; set; } = null!;
        public int Trangthai { get; set; }
        public int S { get; set; }
        public int L { get; set; }
        public int M { get; set; }
        public int Xl { get; set; }

        public virtual Bosutap IdboSuuTapNavigation { get; set; } = null!;
        public virtual Loaisp LoaispNavigation { get; set; } = null!;
        public virtual ICollection<Giohang> Giohangs { get; set; }
    }
}
