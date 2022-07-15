using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebShoppingDotnet.Models
{
    public partial class Hoadon
    {
      

        public string Mahoadon { get; set; } = null!;
        public string Iduser { get; set; } = null!;
        public DateTime? NgayDatHang { get; set; }
        public int TrangThai { get; set; }
        public DateTime? NgayNhanHang { get; set; }
        public int? SoNgayDuKien { get; set; }
        public double TongTien { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual User IduserNavigation { get; set; } = null!;
    }
}
