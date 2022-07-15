using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebShoppingDotnet.Models
{
    public partial class Hinhanh
    {
        public  string Idhinhanh { get; set; } = null!;
        public string Idsp { get; set; } = null!;
        public string Url { get; set; } = null!;
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Product IdspNavigation { get; set; } = null!;
    }
}
