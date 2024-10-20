using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BUS
{
    public class LuongBUS
    {
        private LuongDAL luongDAL;

        public LuongBUS()
        {
            luongDAL = new LuongDAL();
        }

        public List<dynamic> LayDanhSachNhanVienChuaCoLuong()
        {
            return luongDAL.LayDanhSachNhanVienChuaCoLuong();
        }
        public List<NhanVienDTO> LayDanhSachNhanVienChuaCL()
        {
            return luongDAL.LayDanhSachNhanVienChuaCL();
        }
        public void ThemLuong(Luong luong)
        {
            luongDAL.AddLuong(luong);
        }

        public Luong LayLuongTheoMaNhanVien(int maNhanVien)
        {
            return luongDAL.GetLuongByMaNhanVien(maNhanVien);
        }

        public void SuaLuong(Luong luong)
        {
            luongDAL.UpdateLuong(luong);
        }

        public void XoaLuong(int maLuong)
        {
            luongDAL.DeleteLuong(maLuong);
        }
    }
}
