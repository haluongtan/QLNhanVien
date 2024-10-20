using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChamCongBUS
    {
        private ChamCongDAL chamCongDAL;

        public ChamCongBUS()
        {
            chamCongDAL = new ChamCongDAL();
        }

        public List<ChamCong> LayDanhSachChamCongTheoNgay(DateTime ngay)
        {
            return chamCongDAL.LayDanhSachChamCongTheoNgay(ngay);
        }

        public List<NhanVien> LayDanhSachNhanVien()
        {
            return chamCongDAL.LayDanhSachNhanVien();
        }

        public void LuuChamCong(ChamCong chamCong)
        {
            chamCongDAL.LuuChamCong(chamCong);
        }

        public void XoaChamCong(int maNhanVien, DateTime ngay)
        {
            chamCongDAL.XoaChamCong(maNhanVien, ngay);
        }
        public List<NhanVien> LayDanhSachNhanVienChuaChamCong(DateTime ngay)
        {
            return chamCongDAL.LayDanhSachNhanVienChuaChamCong(ngay);
        }

    }
}
