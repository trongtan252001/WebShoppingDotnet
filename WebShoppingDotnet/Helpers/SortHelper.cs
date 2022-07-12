using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebShoppingDotnet.Helpers
{
    public class SortHelper
    {
        public int idSort { get; set; }
        public List<SelectListItem> ListItems { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "name", Text = "Sắp xếp từ A-Z" },
            new SelectListItem { Value = "name_desc", Text = "Sắp xếp từ Z-A" },
            new SelectListItem { Value = "price", Text = "Sắp xếp theo giá tăng dần"  },
            new SelectListItem { Value = "price_desc", Text = "Sắp xếp theo giá giảm dần"  }
        };

    }
}
