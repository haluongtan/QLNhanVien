using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{

    public class NhanVienDAL
    {
        private Model1 dbContext = new Model1();
        public List<NhanVien> LayDanhSachNhanVien()
        {
            return dbContext.NhanVien.ToList();
        }


        public void ThemNhanVien(NhanVien nhanVien)
        {
            dbContext.NhanVien.Add(nhanVien);
            dbContext.SaveChanges();
        }

        public void XoaNhanVien(int maNhanVien)
        {
            var nhanVien = dbContext.NhanVien.SingleOrDefault(nv => nv.MaNhanVien == maNhanVien);
            if (nhanVien != null)
            {
                dbContext.NhanVien.Remove(nhanVien);
                dbContext.SaveChanges();
            }
        }

        public void SuaNhanVien(NhanVien nhanVien)
        {
            var existingNhanVien = dbContext.NhanVien.SingleOrDefault(nv => nv.MaNhanVien == nhanVien.MaNhanVien);
            if (existingNhanVien != null)
            {
                existingNhanVien.HoTen = nhanVien.HoTen;
                existingNhanVien.NgaySinh = nhanVien.NgaySinh;
                existingNhanVien.GioiTinh = nhanVien.GioiTinh;
                existingNhanVien.SDT = nhanVien.SDT;
                existingNhanVien.DiaChi = nhanVien.DiaChi;
                existingNhanVien.MaPhongBan = nhanVien.MaPhongBan;
                existingNhanVien.MaChucVu = nhanVien.MaChucVu;
                existingNhanVien.NgayVaoLam = nhanVien.NgayVaoLam;
                existingNhanVien.Email = nhanVien.Email;
                existingNhanVien.AvatarPath = nhanVien.AvatarPath;

                dbContext.SaveChanges();
            }
        }
        public List<NhanVien> TimKiemNhanVien(string tuKhoa)
        {
            return dbContext.NhanVien
                            .Where(nv => nv.MaNhanVien.ToString().Contains(tuKhoa) ||
                                         nv.HoTen.Contains(tuKhoa) ||
                                         nv.SDT.Contains(tuKhoa))
                            .ToList();
        }

        public NhanVien LayNhanVienTheoMa(int maNhanVien)
        {
            return dbContext.NhanVien.SingleOrDefault(nv => nv.MaNhanVien == maNhanVien);
        }
      
    }

}
