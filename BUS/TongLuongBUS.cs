using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TongLuongBUS
    {
        private TongLuongDAL tongLuongDAL;

        public TongLuongBUS()
        {
            tongLuongDAL = new TongLuongDAL();
        }

        public List<TongLuongDTO> LayDanhSachTongLuong(int thang, int nam)
        {
            return tongLuongDAL.LayDanhSachTongLuong(thang, nam);
        }
    }
}
