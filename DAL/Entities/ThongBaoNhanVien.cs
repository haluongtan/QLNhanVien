using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ThongBaoNhanVien
    {
        [Key]
        public int MaThongBao { get; set; }
        public int MaNhanVien { get; set; }
        public int MaSuKien { get; set; }

        // Liên kết với bảng NhanVien
        public virtual NhanVien NhanVien { get; set; }
        // Liên kết với bảng ThongBaoSuKien
        public virtual ThongBaoSuKien ThongBaoSuKien { get; set; }
    }
}
