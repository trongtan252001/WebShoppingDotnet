using Microsoft.AspNetCore.Mvc;
using System;
using WebShoppingDotnet.Models;

namespace WebShoppingDotnet.Components
{
    [ViewComponent]
    public class ViewMenu:ViewComponent
    {
        ShopthoitrangContext _shopthoitrang = new ShopthoitrangContext();

        public IViewComponentResult Invoke()
        {
            var listLoai = new ShopthoitrangContext().Loaisps.ToList(); 
            return View(listLoai);
        }
    }
}
