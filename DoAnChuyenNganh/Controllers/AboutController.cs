using DoAnChuyenNganh.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoAnChuyenNganh.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;
        private readonly DataContext _context;

        public AboutController(ILogger<AboutController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Route("/list-ve-chung-toi-2.html")]
        public IActionResult About()
        {
            return View();
        }
    }
}
