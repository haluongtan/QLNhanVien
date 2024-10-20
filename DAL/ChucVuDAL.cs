using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class ChucVuDAL
    {
        private Model1 dbContext = new Model1();

        public List<ChucVu> LayDanhSachChucVu()
        {
            return dbContext.ChucVu.ToList();
        }

        public List<NhanVien> LayDanhSachNhanVienTheoChucVu(int maChucVu)
        {
            return dbContext.NhanVien.Where(nv => nv.MaChucVu == maChucVu).ToList();
        }
    }
}
