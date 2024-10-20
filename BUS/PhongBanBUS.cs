using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BUS
{
    public class PhongBanBUS
    {
        private PhongBanDAL phongBanDAL = new PhongBanDAL();

        public List<PhongBan> LayDanhSachPhongBan()
        {
            return phongBanDAL.LayDanhSachPhongBan();
        }

        public List<NhanVien> LayDanhSachNhanVienTheoPhongBan(int maPhongBan)
        {
            return phongBanDAL.LayDanhSachNhanVienTheoPhongBan(maPhongBan);
        }
    }
}
