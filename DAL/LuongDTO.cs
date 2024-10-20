using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LuongDTO
    {
        public int MaLuong { get; set; }
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal PhuCap { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
    }
}
