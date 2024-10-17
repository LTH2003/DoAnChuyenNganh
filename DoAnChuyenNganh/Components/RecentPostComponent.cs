using Microsoft.AspNetCore.Mvc;
using DoAnChuyenNganh.Models;

namespace DoAnChuyenNganh.Components
{
    [ViewComponent(Name = "RecentPost")]
    public class RecentPostComponent : ViewComponent
    {
        private readonly DataContext _context;
        
        public RecentPostComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _context.Posts
                              where (p.IsActive == true) && (p.Status == 1)
                              orderby p.PostID descending
                              select p).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
