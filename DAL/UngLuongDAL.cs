using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DAL
{
    public class UngLuongDAL
    {
        private Model1 dbContext;

        public UngLuongDAL()
        {
            dbContext = new Model1();
        }

        public List<UngLuongDTO> LayDanhSachUngLuong()
        {
            // Không cần tạo lại `dbContext` vì đã có sẵn trong constructor
            // Sử dụng Include để tải các bảng liên quan
            var danhSachUngLuong = dbContext.UngLuong
                                            .Include(ul => ul.NhanVien) // Load thông tin nhân viên
                                            .Include(ul => ul.NhanVien.PhongBan) // Load thông tin phòng ban của nhân viên
                                            .Select(ul => new UngLuongDTO
                                            {
                                                Id = ul.Id,
                                                MaNhanVien = ul.MaNhanVien,
                                                HoTen = ul.NhanVien != null ? ul.NhanVien.HoTen : string.Empty, // Kiểm tra null để tránh lỗi
                                                PhongBan = ul.NhanVien != null && ul.NhanVien.PhongBan != null ? ul.NhanVien.PhongBan.TenPhongBan : string.Empty,
                                                NgayUng = ul.NgayUng,
                                                SoTienUng = ul.SoTienUng
                                            })
                                            .ToList();

            return danhSachUngLuong;
        }
        public List<UngLuong> LayDanhSachUngLuongTheoThang(int thang, int nam)
        {
            using (var dbContext = new Model1())
            {
                var danhSachUngLuong = dbContext.UngLuong
                                                .Include(ul => ul.NhanVien)
                                                .Where(ul => ul.NgayUng.Month == thang && ul.NgayUng.Year == nam)
                                                .ToList();
                return danhSachUngLuong;
            }
        }


        public void ThemUngLuong(UngLuong ungLuong)
        {
            dbContext.UngLuong.Add(ungLuong);
            dbContext.SaveChanges();
        }

        public void SuaUngLuong(UngLuong ungLuong)
        {
            dbContext.Entry(ungLuong).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void XoaUngLuong(int id)
        {
            var ungLuong = dbContext.UngLuong.Find(id);
            if (ungLuong != null)
            {
                dbContext.UngLuong.Remove(ungLuong);
                dbContext.SaveChanges();
            }
        }
    }
}
