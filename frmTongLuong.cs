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
using BUS;

namespace QLNhanVien
{
    public partial class frmTongLuong : Form
    {
        private TongLuongBUS tongLuongBUS;
        private UngLuongBUS ungLuongBUS;


        public frmTongLuong()
        {
            InitializeComponent();
            tongLuongBUS = new TongLuongBUS();
            ungLuongBUS = new UngLuongBUS();


        }

        private void frmTongLuong_Load(object sender, EventArgs e)
        {
            TinhLuongThang();
        }
        public void TinhLuongThang()
        {
            int thangHienTai = DateTime.Now.Month;
            int namHienTai = DateTime.Now.Year;

            // Lấy danh sách tổng lương cho từng nhân viên
            var danhSachTongLuong = tongLuongBUS.LayDanhSachTongLuong(thangHienTai, namHienTai);

            // Lấy danh sách tiền ứng của từng nhân viên
            var danhSachUngLuong = ungLuongBUS.LayDanhSachUngLuongTheoThang(thangHienTai, namHienTai);

            // Kết hợp danh sách tổng lương và tiền ứng
            var danhSachTongLuongSauTruUng = danhSachTongLuong.Select(luong =>
            {
                var tienUng = danhSachUngLuong
                    .Where(ul => ul.MaNhanVien == luong.MaNhanVien)
                    .Sum(ul => ul.SoTienUng);

                return new
                {
                    luong.MaNhanVien,
                    luong.HoTen,
                    luong.Thang,
                    luong.Nam,
                    TongLuong = Math.Round(luong.TongLuong - tienUng, 2) // Trừ đi số tiền ứng
                };
            }).ToList();

            // Hiển thị kết quả vào DataGridView
            dgvTongLuong.DataSource = danhSachTongLuongSauTruUng;
            dgvTongLuong.Columns["TongLuong"].DefaultCellStyle.Format = "N2";
        }
       

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

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

                            worksheet.Cells[1, 1].Value = "Mã Nhân Viên";
                            worksheet.Cells[1, 2].Value = "Họ Tên";
                            worksheet.Cells[1, 3].Value = "Tháng";
                            worksheet.Cells[1, 4].Value = "Năm";
                            worksheet.Cells[1, 5].Value = "Tổng Lương";

                            using (var range = worksheet.Cells[1, 1, 1, 5])
                            {
                                range.Style.Font.Bold = true;
                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                            }

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

                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
