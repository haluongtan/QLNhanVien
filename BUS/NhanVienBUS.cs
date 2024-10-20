using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVienBUS
    {
        private NhanVienDAL nhanVienDAL = new NhanVienDAL(); 

        public List<NhanVien> LayDanhSachNhanVien()
        {
            return nhanVienDAL.LayDanhSachNhanVien();
        }

        public void ThemNhanVien(NhanVien nhanVien)
        {
            nhanVienDAL.ThemNhanVien(nhanVien);
        }

        public void XoaNhanVien(int maNhanVien)
        {
            nhanVienDAL.XoaNhanVien(maNhanVien);
        }

        public void SuaNhanVien(NhanVien nhanVien)
        {
            nhanVienDAL.SuaNhanVien(nhanVien);
        }
        public NhanVien LayNhanVienTheoMa(int maNhanVien)
        {
            return nhanVienDAL.LayNhanVienTheoMa(maNhanVien);
        }
        public List<NhanVien> TimKiemNhanVien(string tuKhoa)
        {
            return nhanVienDAL.TimKiemNhanVien(tuKhoa);
        }

    }
}
