using Microsoft.AspNetCore.Mvc;
using DoAnChuyenNganh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoAnChuyenNganh.Utilities;

namespace DoAnChuyenNganh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");

            return View();
        }
        public IActionResult Menu()
        {
            var mnList = _context.Menus.OrderBy(m => m.MenuID).Take(1).ToList();
            return View(mnList);
        }
        public IActionResult Post()
        {
            var postList = _context.Posts.OrderBy(m => m.PostID).ToList();
            return View(postList);
        }
        public IActionResult SanPham()
        {
            var spList = _context.SanPhams.OrderBy(s => s.MaTour).ToList();
            return View(spList);
        }

        public IActionResult CreateSP()
        {
            var spList = (from s in _context.SanPhams
                            select new SelectListItem()
                            {
                                Text = s.TenTour,
                                Value = s.MaTour.ToString(),
                            }).ToList();
            spList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.spList = spList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSP(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                _context.SanPhams.Add(sp);
                _context.SaveChanges();
                return RedirectToAction("SanPham");
            }
            return View(sp);
        }

        public IActionResult EditSP(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sp = _context.SanPhams.Find(id);
            if (sp == null)
            {
                return NotFound();
            }
            var spList = (from s in _context.SanPhams
                            select new SelectListItem()
                            {
                                Text = s.TenTour,
                                Value = s.MaTour.ToString(),
                            }).ToList();
            spList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.spList = spList;
            return View(sp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSP(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                _context.SanPhams.Update(sp);
                _context.SaveChanges();
                return RedirectToAction("SanPham");
            }
            return View(sp);
        }

        public IActionResult DeleteSP(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sp = _context.SanPhams.Find(id);
            if (sp == null)
            {
                return NotFound();
            }
            return View(sp);
        }
        [HttpPost]
        public IActionResult DeleteSP(int id)
        {
            var deleSP = _context.SanPhams.Find(id);
            if (deleSP == null)
            {
                return NotFound();
            }
            _context.SanPhams.Remove(deleSP);
            _context.SaveChanges();
            return RedirectToAction("SanPham");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }
            var mn = _context.Menus.Find(id);
            if (mn == null) 
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleMenu = _context.Menus.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _context.Menus.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Menu");
        }

        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var delePost = _context.Posts.Find(id);
            if (delePost == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(delePost);
            _context.SaveChanges();
            return RedirectToAction("Post");
        }

        public IActionResult Create()
        {
            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.mnList = mnList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Menu mn)
        {
            if (ModelState.IsValid)
            {
                _context.Menus.Add(mn);
                _context.SaveChanges();
                return RedirectToAction("Menu");
            }
            return View(mn);
        }
        public IActionResult CreatePost()
        {
            var postList = (from p in _context.Posts
                          select new SelectListItem()
                          {
                              Text = p.Title,
                              Value = p.PostID.ToString(),
                          }).ToList();
            postList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.postList = postList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Post");
            }
            return View(post);
        }
        public  IActionResult Edit(int? id) 
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }    
            var mn = _context.Menus.Find(id);
            if(mn == null)
            {
                return NotFound();
            }
            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Menu mn)
        {
            if(ModelState.IsValid)
            {
                _context.Menus.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Menu");
            }
            return View(mn);
        }

        public IActionResult EditPost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            var postList = (from p in _context.Posts
                          select new SelectListItem()
                          {
                              Text = p.Title,
                              Value = p.PostID.ToString(),
                          }).ToList();
            postList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.postList = postList;
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Update(post);
                _context.SaveChanges();
                return RedirectToAction("Post");
            }
            return View(post);
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
    }
}
