using DAL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class UngLuongBUS
    {
        private UngLuongDAL ungLuongDAL;

        public UngLuongBUS()
        {
            ungLuongDAL = new UngLuongDAL();
        }


        public List<UngLuongDTO> LayDanhSachUngLuong()
        {
            return ungLuongDAL.LayDanhSachUngLuong();
        }

        public List<UngLuong> LayDanhSachUngLuongTheoThang(int thang, int nam)
        {
            return ungLuongDAL.LayDanhSachUngLuongTheoThang(thang, nam);
        }

        public void ThemUngLuong(UngLuong ungLuong)
        {
            ungLuongDAL.ThemUngLuong(ungLuong);
        }

        public void SuaUngLuong(UngLuong ungLuong)
        {
            ungLuongDAL.SuaUngLuong(ungLuong);
        }

        public void XoaUngLuong(int id)
        {
            ungLuongDAL.XoaUngLuong(id);
        }
    }
}
