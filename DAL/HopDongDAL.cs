using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;


namespace DAL
{
    public class HopDongDAL
    {
        private Model1 dbContext = new Model1();
        public List<dynamic> LayDanhSachHopDong()
        {
            var hopDongData = (from hd in dbContext.HopDong
                               join nv in dbContext.NhanVien on hd.MaNhanVien equals nv.MaNhanVien
                               select new
                               {
                                   hd.MaHopDong,
                                   hd.MaNhanVien,
                                   TenNhanVien = nv.HoTen,
                                   hd.LoaiHopDong,
                                   hd.NgayKy,
                                   hd.NgayHetHan
                               }).ToList<object>();
            return hopDongData;
        }

        public HopDong LayHopDongTheoMa(int maHopDong)
        {
            return dbContext.HopDong.FirstOrDefault(hd => hd.MaHopDong == maHopDong);
        }

        // Thêm mới hợp đồng
        public void ThemHopDong(HopDong hopDong)
        {
            dbContext.HopDong.Add(hopDong);
            dbContext.SaveChanges();
        }

        // Sửa hợp đồng
        public void SuaHopDong(HopDong hopDong)
        {
            dbContext.Entry(hopDong).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        // Xóa hợp đồng
        public void XoaHopDong(int maHopDong)
        {
            var hopDong = dbContext.HopDong.FirstOrDefault(hd => hd.MaHopDong == maHopDong);
            if (hopDong != null)
            {
                dbContext.HopDong.Remove(hopDong);
                dbContext.SaveChanges();
            }
        }

        // Tìm hợp đồng theo từ khóa tên nhân viên
        public List<dynamic> TimKiemHopDong(string tuKhoa)
        {
            var ketQuaTimKiem = (from hd in dbContext.HopDong
                                 join nv in dbContext.NhanVien on hd.MaNhanVien equals nv.MaNhanVien
                                 where nv.HoTen.Contains(tuKhoa)
                                 select new
                                 {
                                     hd.MaHopDong,
                                     hd.MaNhanVien,
                                     TenNhanVien = nv.HoTen,
                                     hd.LoaiHopDong,
                                     hd.NgayKy,
                                     hd.NgayHetHan
                                 }).ToList<object>(); ;
            return ketQuaTimKiem;
        }
    }
}
