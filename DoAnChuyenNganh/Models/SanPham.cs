using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnChuyenNganh.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]

        public int MaTour { get; set; }

        public string? TenTour { get; set; }

        public string? AnhTour { get; set; }

        public string? Price { get; set; }

        public int MaMTSP { get; set; }

        public int MaLoai { get; set; }

        public string? TimeTour { get; set; }

        public string? DiaDiem { get; set; }

        public int PhongTam { get; set; }

        public int PhongNgu {  get; set; }

        public string? KhuVuc {  get; set; }
    }
}
