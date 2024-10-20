using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;


namespace DAL
{
    public class LuongDAL
    {
        private Model1 dbContext;

        public LuongDAL()
        {
            dbContext = new Model1();
        }

        public List<dynamic> LayDanhSachNhanVienChuaCoLuong()
        {
            var nhanVienChuaCoLuong = (from l in dbContext.Luong
                                       join nv in dbContext.NhanVien on l.MaNhanVien equals nv.MaNhanVien
                                       select new
                                       {
                                           l.MaLuong,
                                           l.MaNhanVien,
                                           TenNhanVien = nv.HoTen,
                                           l.LuongCoBan,
                                           l.PhuCap,
                                           l.Thang,
                                           l.Nam
                                       }).ToList<dynamic>();

            return nhanVienChuaCoLuong;
        }
        public List<NhanVienDTO> LayDanhSachNhanVienChuaCL()
        {
            var nhanVienChuaCL = (from nv in dbContext.NhanVien
                                  where !(from l in dbContext.Luong
                                          select l.MaNhanVien).Contains(nv.MaNhanVien)
                                  select new NhanVienDTO
                                  {
                                      MaNhanVien = nv.MaNhanVien,
                                      HoTen = nv.HoTen,
                                      MaPhongBan = nv.MaPhongBan,
                                      MaChucVu = nv.MaChucVu
                                  }).ToList();

            return nhanVienChuaCL;
        }


        public void AddLuong(Luong luong)
        {
            dbContext.Luong.Add(luong);
            dbContext.SaveChanges();
        }

        public Luong GetLuongByMaNhanVien(int maNhanVien)
        {
            return dbContext.Luong.FirstOrDefault(l => l.MaNhanVien == maNhanVien);
        }

        public void UpdateLuong(Luong luong)
        {
            dbContext.Entry(luong).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void DeleteLuong(int maLuong)
        {
            var luong = dbContext.Luong.FirstOrDefault(l => l.MaLuong == maLuong);
            if (luong != null)
            {
                dbContext.Luong.Remove(luong);
                dbContext.SaveChanges();
            }
        }
    }
}
