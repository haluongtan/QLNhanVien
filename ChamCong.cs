namespace QLNhanVien
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChamCong")]
    public partial class ChamCong
    {
        public int? MaNhanVien { get; set; }

        [StringLength(100)]
        public string TenNhanVien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [Key]
        public int MaChamCong { get; set; }
    }
}
