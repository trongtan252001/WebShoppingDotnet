using System;
using System.Collections.Generic;

namespace WebShoppingDotnet.Models
{
    public partial class Quangcao
    {
        public string? Id { get; set; }
        public string Tieude { get; set; } = null!;
        public string Mota { get; set; } = null!;
        public string UrlImg { get; set; } = null!;
        public string Url { get; set; } = null!;
    }
}
