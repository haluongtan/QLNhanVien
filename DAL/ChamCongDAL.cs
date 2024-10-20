using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChamCongDAL
    {
        private Model1 dbContext;

        public ChamCongDAL()
        {
            dbContext = new Model1();
        }

        public List<ChamCong> LayDanhSachChamCongTheoNgay(DateTime ngay)
        {
            return dbContext.ChamCong
                            .Where(cc => DbFunctions.TruncateTime(cc.Ngay) == ngay.Date)
                            .ToList();
        }

        public List<NhanVien> LayDanhSachNhanVien()
        {
            return dbContext.NhanVien.ToList();
        }

        public void LuuChamCong(ChamCong chamCong)
        {
            var existingRecord = dbContext.ChamCong
                                          .FirstOrDefault(cc => cc.MaNhanVien == chamCong.MaNhanVien &&
                                                                DbFunctions.TruncateTime(cc.Ngay) == DbFunctions.TruncateTime(chamCong.Ngay.Value));
            if (existingRecord != null)
            {
                existingRecord.TrangThai = chamCong.TrangThai;
            }
            else
            {
                dbContext.ChamCong.Add(chamCong);
            }

            dbContext.SaveChanges();
        }

        public void XoaChamCong(int maNhanVien, DateTime ngay)
        {
            var chamCongToDelete = dbContext.ChamCong
                                            .FirstOrDefault(cc => cc.MaNhanVien == maNhanVien &&
                                                                  DbFunctions.TruncateTime(cc.Ngay) == ngay.Date);
            if (chamCongToDelete != null)
            {
                dbContext.ChamCong.Remove(chamCongToDelete);
                dbContext.SaveChanges();
            }
        }
        public List<NhanVien> LayDanhSachNhanVienChuaChamCong(DateTime ngay)
        {
            var nhanVienList = dbContext.NhanVien
                                .Where(nv => !dbContext.ChamCong
                                .Any(cc => cc.MaNhanVien == nv.MaNhanVien && DbFunctions.TruncateTime(cc.Ngay) == ngay.Date))
                                .ToList();

            return nhanVienList;
        }
    }
}
