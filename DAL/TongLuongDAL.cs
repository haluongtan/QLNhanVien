using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TongLuongDAL
    {
        private Model1 dbContext;
        public TongLuongDAL()
        {
            dbContext = new Model1();
        }

        public List<TongLuongDTO> LayDanhSachTongLuong(int thang, int nam)
        {
            var danhSachNhanVien = (from nv in dbContext.NhanVien
                                    join l in dbContext.Luong on nv.MaNhanVien equals l.MaNhanVien
                                    select new
                                    {
                                        nv.MaNhanVien,
                                        nv.HoTen,
                                        LuongCoBan = l.LuongCoBan,
                                        ChamCong = dbContext.ChamCong
                                            .Where(cc => cc.MaNhanVien == nv.MaNhanVien &&
                                                         cc.Ngay.HasValue &&
                                                         cc.Ngay.Value.Month == thang &&
                                                         cc.Ngay.Value.Year == nam)
                                            .ToList()
                                    }).ToList();

            var danhSachTongLuong = danhSachNhanVien.Select(nv => new TongLuongDTO
            {
                MaNhanVien = nv.MaNhanVien,
                HoTen = nv.HoTen,
                Thang = thang,
                Nam = nam,
                TongLuong = Math.Round(CalculateTotalSalary(nv.LuongCoBan ?? 0, 26,
                    nv.ChamCong.Count(cc => cc.TrangThai == "Đi Làm"),
                    nv.ChamCong.Count(cc => cc.TrangThai == "Đi Trễ"),
                    nv.ChamCong.Count(cc => cc.TrangThai == "Nghỉ Phép"),
                    nv.ChamCong.Count(cc => cc.TrangThai == "Không Đi Làm")), 2)
            }).ToList();

            return danhSachTongLuong;
        }


        private decimal CalculateTotalSalary(decimal luongCoBan, int soNgayLamViecTrongThang, int soNgayDiLam, int soNgayDiTre, int soNgayNghiPhep, int soNgayKhongDiLam)
        {
            decimal luongTheoNgay = luongCoBan / soNgayLamViecTrongThang;
            decimal luongThucTe = (soNgayDiLam * luongTheoNgay) +
                                  (soNgayDiTre * luongTheoNgay * 0.95m) +
                                  (soNgayNghiPhep * luongTheoNgay) -
                                  (soNgayKhongDiLam * luongTheoNgay);
            return luongThucTe;
        }
    }
}
