using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAnChuyenNganh.Models;
using DoAnChuyenNganh.Utilities;
using DoAnChuyenNganh.Areas.Admin.Models;

namespace DoAnChuyenNganh.Controllers
{
    public class HomeRegisterController : Controller
    {
        private readonly DataContext _context;

        public HomeRegisterController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(HomeUser user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var check = _context.HomeUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                Functions._MessageEmail = "Duplicate Email!";
                return RedirectToAction("Index", "HomeRegister");
            }
            Functions._MessageEmail = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}
