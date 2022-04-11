using System;
using System.Collections.Generic;

namespace WebShoppingDotnet.Models
{
    public partial class Bosutap
    {
        public Bosutap()
        {
            Products = new HashSet<Product>();
        }

        public string IdBst { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Tieude { get; set; }
        public string? MotaBst { get; set; }
        public string? Img { get; set; }
        public int? Check { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
