namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HopDong")]
    public partial class HopDong
    {
        [Key]
        public int MaHopDong { get; set; }

        public int? MaNhanVien { get; set; }

        [StringLength(100)]
        public string LoaiHopDong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }
    }
}
