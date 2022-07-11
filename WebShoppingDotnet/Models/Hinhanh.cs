using System;
using System.Collections.Generic;

namespace WebShoppingDotnet.Models
{
    public partial class Hinhanh
    {
        public  string Idhinhanh { get; set; } = null!;
        public string Idsp { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual Product IdspNavigation { get; set; } = null!;
    }
}
