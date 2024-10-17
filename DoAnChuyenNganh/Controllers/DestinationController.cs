using DoAnChuyenNganh.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnChuyenNganh.Controllers
{
    public class DestinationController : Controller
    {
        private readonly ILogger<DestinationController> _logger;
        private readonly DataContext _context;

        public DestinationController(ILogger<DestinationController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Route("/list-diem-den-3.html")]
        public IActionResult Destination(int? id)
        {
            var destination = _context.SanPhams.ToList();
            return View(destination);
        }
    }
}
