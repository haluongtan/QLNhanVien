namespace QLNhanVien
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HopDong")]
    public partial class HopDong
    {
        public int? MaNhanVien { get; set; }

        [StringLength(50)]
        public string LoaiHopDong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }

        [Key]
        public int MaHopDong { get; set; }
    }
}
