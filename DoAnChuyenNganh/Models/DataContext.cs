using Microsoft.EntityFrameworkCore;
using DoAnChuyenNganh.Models;
using DoAnChuyenNganh.Areas.Admin.Models;

namespace DoAnChuyenNganh.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<view_Post_Menu> Post_Menus { get; set; }

        public DbSet<view_About_Menu> About_Menus { get; set; }

        public DbSet<AdminMenu> AdminMenus {  get; set; } 

        public DbSet<AdminUser> AdminUsers { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<SanPham> SanPhams { get; set; }

        public DbSet<HomeUser> HomeUsers { get; set; }
    }
}
