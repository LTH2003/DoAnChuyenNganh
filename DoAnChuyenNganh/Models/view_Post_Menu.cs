using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnChuyenNganh.Models
{
    [Table("view_Post_Menu")]
    public class view_Post_Menu
    {
        [Key]
        public int PostID { get; set; }

        public string? Title { get; set; }

        public string? Abstract { get; set; }

        public string? Contents { get; set; }

        public string? Images { get; set; }

        public string? Author { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool? IsActive { get; set; }

        public int PostOrder { get; set; }

        [ForeignKey("MenuID")]
        public int MenuID { get; set; }

        public int Category { get; set; }

        public int Status { get; set; }

        public string? MenuName { get; set; }

    }
}
