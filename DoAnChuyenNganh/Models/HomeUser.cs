﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnChuyenNganh.Models
{
    [Table("HomeUser")]
    public class HomeUser
    {
        [Key]

        public int UserID { get; set; }

        public string? UserName { get; set; }

        public string? Email {  get; set; }

        public string? Password { get; set; }

        public bool? IsActive { get; set; }

    }
}
