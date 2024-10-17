using DoAnChuyenNganh.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DoAnChuyenNganh.Utilities;

namespace DoAnChuyenNganh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "HomeLogin");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/post-{slug}-{id:long}.html", Name ="Details")]

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }    
            var post = _context.Posts.FirstOrDefault(m => (m.PostID == id) && (m.IsActive == true));
            if(post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [Route("/list-{slug}-{id:int}.html", Name = "List")]
        public IActionResult List(int? id) 
        {
            if(id == null)
            {
                return NotFound();
            }
            var list = _context.Post_Menus
                .Where(m => (m.MenuID == id) && (m.IsActive == true))
                .Take(3).ToList();
            if(list == null)
            {
                return NotFound();
            }
            return View(list);
        }
		public IActionResult Logout()
		{
			Functions._UserID = 0;
			Functions._UserName = string.Empty;
			Functions._Email = string.Empty;
			Functions._Message = string.Empty;
			Functions._MessageEmail = string.Empty;
			return RedirectToAction("Index", "Home");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}