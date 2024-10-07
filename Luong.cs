namespace QLNhanVien
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Luong")]
    public partial class Luong
    {
        [Key]
        public int MaLuong { get; set; }

        public int? MaNhanVien { get; set; }

        public decimal? LuongCoBan { get; set; }

        public decimal? PhuCap { get; set; }

        public int? Thang { get; set; }

        public int? Nam { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
