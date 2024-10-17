using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnChuyenNganh.Models
{
    [Table("About")]
    public class About
    {
        [Key]

        public int AboutID { get; set; }

        public string? Title { get; set; }

        public string? MetaTitle { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? Detail { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public string? MetaKeywords { get; set; }

        public string? MetaDescriptions { get; set;}

        public bool? IsActive { get; set; }

        public int MenuID { get; set; }
    }
}
