using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UngLuongDTO
    {
        public int Id { get; set; }
        public int MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string PhongBan { get; set; }
        public DateTime NgayUng { get; set; }
        public decimal SoTienUng { get; set; }
    }
}
