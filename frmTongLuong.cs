using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanVien
{
    public partial class frmTongLuong : Form
    {
        public frmTongLuong()
        {
            InitializeComponent();
        }

        private void frmTongLuong_Load(object sender, EventArgs e)
        {
            TinhLuongThang();
        }
        public void TinhLuongThang()
        {
            using (var dbContext = new Model1())
            {
                int thangHienTai = DateTime.Now.Month;
                int namHienTai = DateTime.Now.Year;

                // Lấy dữ liệu chấm công và lương cơ bản
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
                                                             cc.Ngay.Value.Month == thangHienTai &&
                                                             cc.Ngay.Value.Year == namHienTai)
                                                .ToList()
                                        }).ToList();

                // Tính toán lương cho từng nhân viên sau khi lấy dữ liệu từ cơ sở dữ liệu
                var danhSachTongLuong = danhSachNhanVien.Select(nv => new
                {
                    nv.MaNhanVien,
                    nv.HoTen,
                    Thang = thangHienTai,
                    Nam = namHienTai,
                    TongLuong = Math.Round(CalculateTotalSalary(nv.LuongCoBan ?? 0, 26,
        nv.ChamCong.Count(cc => cc.TrangThai == "Đi Làm"),
        nv.ChamCong.Count(cc => cc.TrangThai == "Đi Trễ"),
        nv.ChamCong.Count(cc => cc.TrangThai == "Nghỉ Phép"),
        nv.ChamCong.Count(cc => cc.TrangThai == "Không Đi Làm")), 2)
                }).ToList();

                dgvTongLuong.DataSource = danhSachTongLuong;
                dgvTongLuong.Columns["TongLuong"].DefaultCellStyle.Format = "N2";
            }
        }
        private decimal CalculateTotalSalary(decimal luongCoBan, int soNgayLamViecTrongThang, int soNgayDiLam, int soNgayDiTre, int soNgayNghiPhep, int soNgayKhongDiLam)
        {
            // Lương cho ngày làm đủ
            decimal luongTheoNgay = luongCoBan / soNgayLamViecTrongThang;

            // Lương thực tế
            decimal luongThucTe = (soNgayDiLam * luongTheoNgay) +
                                  (soNgayDiTre * luongTheoNgay * 0.95m) +  // Lương cho đi trễ, giảm 5%
                                  (soNgayNghiPhep * luongTheoNgay) -       // Nghỉ phép tính như ngày làm đủ
                                  (soNgayKhongDiLam * luongTheoNgay);      // Không đi làm, trừ lương

            return luongThucTe;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // Sử dụng EPPlus cho mục đích phi thương mại

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";
                saveFileDialog.FileName = "TongLuong.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        using (ExcelPackage package = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tổng Lương");

                            // Tạo tiêu đề cho các cột trong Excel
                            worksheet.Cells[1, 1].Value = "Mã Nhân Viên";
                            worksheet.Cells[1, 2].Value = "Họ Tên";
                            worksheet.Cells[1, 3].Value = "Tháng";
                            worksheet.Cells[1, 4].Value = "Năm";
                            worksheet.Cells[1, 5].Value = "Tổng Lương";

                            // Định dạng tiêu đề
                            using (var range = worksheet.Cells[1, 1, 1, 5])
                            {
                                range.Style.Font.Bold = true;
                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                            }

                            // Lấy dữ liệu từ DataGridView và điền vào Excel
                            int rowIndex = 2;
                            foreach (DataGridViewRow row in dgvTongLuong.Rows)
                            {
                                worksheet.Cells[rowIndex, 1].Value = row.Cells["MaNhanVien"].Value;
                                worksheet.Cells[rowIndex, 2].Value = row.Cells["HoTen"].Value;
                                worksheet.Cells[rowIndex, 3].Value = row.Cells["Thang"].Value;
                                worksheet.Cells[rowIndex, 4].Value = row.Cells["Nam"].Value;
                                worksheet.Cells[rowIndex, 5].Value = row.Cells["TongLuong"].Value;

                                rowIndex++;
                            }

                            // Định dạng chiều rộng các cột cho vừa dữ liệu
                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                            // Lưu file Excel
                            FileInfo excelFile = new FileInfo(filePath);
                            package.SaveAs(excelFile);
                        }

                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
