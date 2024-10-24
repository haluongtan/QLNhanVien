using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("ThongBaoSuKien")]
    public class ThongBaoSuKien
    {
        [Key]
        public int MaSuKien { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayGioToChuc { get; set; }
        public string LoaiSuKien { get; set; }

        // Quan hệ với ThongBaoNhanVien
        public virtual ICollection<ThongBaoNhanVien> ThongBaoNhanViens { get; set; }
    }
}
