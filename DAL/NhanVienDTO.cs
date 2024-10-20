using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDTO
    {
        public int MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public int? MaPhongBan { get; set; }
        public int? MaChucVu { get; set; }
    }
}
