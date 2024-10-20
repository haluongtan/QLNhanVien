using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class PhongBanDAL
    {
        private Model1 dbContext = new Model1();

        public List<PhongBan> LayDanhSachPhongBan()
        {
            return dbContext.PhongBan.ToList();
        }

        public List<NhanVien> LayDanhSachNhanVienTheoPhongBan(int maPhongBan)
        {
            return dbContext.NhanVien.Where(nv => nv.MaPhongBan == maPhongBan).ToList();
        }
    }
}
