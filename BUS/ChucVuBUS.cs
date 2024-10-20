using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;


namespace BUS
{
    public class ChucVuBUS
    {
        private ChucVuDAL chucVuDAL = new ChucVuDAL();
        private Dictionary<int, int> luongTheoChucVu = new Dictionary<int, int>
        {
            { 1, 10000 }, 
            { 2, 15000 },  
            { 3, 12000 }   
        };

        // Lấy danh sách chức vụ
        public List<ChucVu> LayDanhSachChucVu()
        {
            return chucVuDAL.LayDanhSachChucVu();
        }

        // Lấy danh sách nhân viên theo mã chức vụ
        public List<NhanVien> LayDanhSachNhanVienTheoChucVu(int maChucVu)
        {
            return chucVuDAL.LayDanhSachNhanVienTheoChucVu(maChucVu);
        }

        // Lấy lương theo mã chức vụ
        public int? LayLuongTheoChucVu(int maChucVu)
        {
            return luongTheoChucVu.ContainsKey(maChucVu) ? (int?)luongTheoChucVu[maChucVu] : null;
        }
    }
}
