namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TongLuong")]
    public partial class TongLuong
    {
        [Key]
        public int MaLuong { get; set; }

        public int MaNhanVien { get; set; }

        [StringLength(100)]
        public string TenNhanVien { get; set; }

        public int? Thang { get; set; }

        public int? Nam { get; set; }

        [Column("TongLuong")]
        public decimal? TongLuong1 { get; set; }
    }
}
