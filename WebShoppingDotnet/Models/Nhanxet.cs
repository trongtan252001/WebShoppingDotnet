using System;
using System.Collections.Generic;

namespace WebShoppingDotnet.Models
{
    public partial class Nhanxet
    {
        public string IdnhanXet { get; set; } = null!;
        public string Iduser { get; set; } = null!;
        public string Imguser { get; set; } = null!;
        public string Nhanxet1 { get; set; } = null!;
        public DateOnly Ngay { get; set; }
        public int Status { get; set; }
        public string Job { get; set; } = null!;

        public virtual User IduserNavigation { get; set; } = null!;
    }
}
