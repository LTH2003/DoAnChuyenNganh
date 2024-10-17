using Microsoft.AspNetCore.Mvc;
using DoAnChuyenNganh.Areas.Admin.Models;
using DoAnChuyenNganh.Models;
using DoAnChuyenNganh.Utilities;

namespace DoAnChuyenNganh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DataContext _context;

        public RegisterController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminUser user)
        {
            if(user == null)
            {
                return NotFound();
            }
            var check = _context.AdminUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            if(check != null) 
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
