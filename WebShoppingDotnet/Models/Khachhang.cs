using System;
using System.Collections.Generic;

namespace WebShoppingDotnet.Models
{
    public partial class Khachhang
    {
        public string Iduser { get; set; } = null!;
        public string HoTen { get; set; } = null!;
        public string DienThoai { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public string TinhTp { get; set; } = null!;
        public string QuanHuyen { get; set; } = null!;
        public string PhuongXa { get; set; } = null!;

        public virtual User IduserNavigation { get; set; } = null!;
    }
}
