using BUS;
using DAL.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class frmQuanLySuKien : Form
    {
        private ThongBaoSuKienBUS thongBaoSuKienBUS;

        public frmQuanLySuKien()
        {
            InitializeComponent();
            thongBaoSuKienBUS = new ThongBaoSuKienBUS();

        }

        private void frmQuanLySuKien_Load(object sender, EventArgs e)
        {
            LoadSuKienData();
            cmbLoaiSuKien.Items.Clear();
            cmbLoaiSuKien.Items.Add("Đào tạo");
            cmbLoaiSuKien.Items.Add("Hội thảo");
            cmbLoaiSuKien.Items.Add("Hoạt động ngoại khóa");
            cmbLoaiSuKien.Items.Add("Gặp mặt");
            cmbLoaiSuKien.Items.Add("Khen thưởng");
            cmbLoaiSuKien.Items.Add("Khóa học nâng cao kỹ năng");
            cmbLoaiSuKien.Items.Add("Họp định kỳ");
            cmbLoaiSuKien.Items.Add("Sự kiện văn hóa công ty");
            cmbLoaiSuKien.Items.Add("Sinh nhật");
            cmbLoaiSuKien.Items.Add("Thông báo quan trọng");

            // Đặt loại sự kiện mặc định
            cmbLoaiSuKien.SelectedIndex = 0;
            dgvSuKien.Columns["MaSuKien"].Visible = false;
            if (dgvSuKien.Columns["ThongBaoNhanViens"] != null)
            {
                dgvSuKien.Columns["ThongBaoNhanViens"].Visible = false;
            }


        }
        private void LoadSuKienData()
        {
            var danhSachSuKien = thongBaoSuKienBUS.LayDanhSachSuKien();
            dgvSuKien.DataSource = danhSachSuKien;

            // Điều chỉnh kích thước cột tự động cho phù hợp với nội dung
            dgvSuKien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLuuSuKien_Click(object sender, EventArgs e)
        {
            try
            {
                ThongBaoSuKien suKien = new ThongBaoSuKien()
                {
                    TieuDe = txtTieuDe.Text.Trim(),
                    NoiDung = rtbNoiDung.Text.Trim(),
                    NgayGioToChuc = dtpNgayGioToChuc.Value,
                    LoaiSuKien = cmbLoaiSuKien.Text
                };

                thongBaoSuKienBUS.ThemSuKien(suKien);
                MessageBox.Show("Thêm sự kiện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSuKienData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            if (dgvSuKien.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dgvSuKien.CurrentRow;
                int maSuKien = (int)selectedRow.Cells["MaSuKien"].Value;
                string tieuDe = selectedRow.Cells["TieuDe"].Value.ToString();
                string noiDung = selectedRow.Cells["NoiDung"].Value.ToString();
                DateTime ngayGioToChuc = (DateTime)selectedRow.Cells["NgayGioToChuc"].Value;
                string loaiSuKien = selectedRow.Cells["LoaiSuKien"].Value.ToString();

                string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã nhân viên cần gửi:", "Gửi Email", "");
                if (int.TryParse(input, out int maNhanVien))
                {
                    try
                    {
                        string noiDungEmail = $"{noiDung}\n\nThời gian tổ chức: {ngayGioToChuc}\nLoại sự kiện: {loaiSuKien}";
                        thongBaoSuKienBUS.GuiThongBaoQuaEmail(maNhanVien, tieuDe, noiDungEmail);
                        MessageBox.Show("Gửi thông báo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã nhân viên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sự kiện để gửi email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvSuKien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvSuKien.Rows[e.RowIndex];

                // Gán giá trị của dòng được chọn vào các TextBox và điều khiển khác
                txtTieuDe.Text = selectedRow.Cells["TieuDe"].Value?.ToString() ?? string.Empty;
                rtbNoiDung.Text = selectedRow.Cells["NoiDung"].Value?.ToString() ?? string.Empty;

                if (selectedRow.Cells["NgayGioToChuc"].Value != null)
                {
                    dtpNgayGioToChuc.Value = Convert.ToDateTime(selectedRow.Cells["NgayGioToChuc"].Value);
                }

                if (selectedRow.Cells["LoaiSuKien"].Value != null)
                {
                    string loaiSuKien = selectedRow.Cells["LoaiSuKien"].Value.ToString();
                    cmbLoaiSuKien.SelectedItem = loaiSuKien;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSuKien.CurrentRow != null)
            {
                try
                {
                    // Lấy sự kiện được chọn từ DataGridView
                    DataGridViewRow selectedRow = dgvSuKien.CurrentRow;
                    int maSuKien = (int)selectedRow.Cells["MaSuKien"].Value;

                    // Xác nhận người dùng có muốn xóa sự kiện không
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sự kiện này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        thongBaoSuKienBUS.XoaSuKien(maSuKien);
                        MessageBox.Show("Xóa sự kiện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSuKienData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa sự kiện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sự kiện để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
 
}
