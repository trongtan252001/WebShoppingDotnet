using System;
using System.Collections.Generic;
using System.Globalization;

namespace WebShoppingDotnet.Models
{
    public partial class Product
    {
        public Product()
        {
            Giohangs = new HashSet<Giohang>();
            Hinhanhs = new List<Hinhanh>();
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

        public float GetSaleToday()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            if (today >= Ngaybatdausale && today <= Ngayketthucsale)
            {
                return Sale;
            }
            else
            {
                return 0;
            }
        }

        public int GetSize(String size)
        {
            switch (size.ToUpper())
            {
                case "S":
                    return S;
                case "L":
                    return L;
                case "M":
                    return M;
                case "XL":
                    return Xl;
            }

            return -1;
        }
        public string ParseCurrencyVND(float input)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            return double.Parse(input+"").ToString("#,###", cul.NumberFormat)+" đ";
        }
        public virtual Bosutap IdboSuuTapNavigation { get; set; } = null!;
        public virtual Loaisp LoaispNavigation { get; set; } = null!;
        public virtual ICollection<Giohang> Giohangs { get; set; }
        public virtual ICollection<Hinhanh> Hinhanhs { get; set; }

    }
}
