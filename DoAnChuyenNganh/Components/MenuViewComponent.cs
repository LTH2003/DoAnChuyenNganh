﻿using Microsoft.AspNetCore.Mvc;
using DoAnChuyenNganh.Models;

namespace DoAnChuyenNganh.Components
{
    [ViewComponent(Name = "MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private DataContext _context;
        public MenuViewComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from m in _context.Menus
                              where (m.IsActive == true) && (m.Position == 1)
                              select m).Take(1).ToList();   
            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));
        }
    }
}
