using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BUS
{
    public class HopDongBus
    {
        private HopDongDAL hopDongDAL = new HopDongDAL();
        public List<dynamic> LayDanhSachHopDong()
        {
            return hopDongDAL.LayDanhSachHopDong();
        }

        // Thêm hợp đồng mới
        public void ThemHopDong(HopDong hopDong)
        {
            hopDongDAL.ThemHopDong(hopDong);
        }

        // Sửa hợp đồng
        public void SuaHopDong(HopDong hopDong)
        {
            hopDongDAL.SuaHopDong(hopDong);
        }

        // Xóa hợp đồng
        public void XoaHopDong(int maHopDong)
        {
            hopDongDAL.XoaHopDong(maHopDong);
        }

        // Tìm kiếm hợp đồng theo từ khóa
        public List<dynamic> TimKiemHopDong(string tuKhoa)
        {
            return hopDongDAL.TimKiemHopDong(tuKhoa);
        }
    }
}
