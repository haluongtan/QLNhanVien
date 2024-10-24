using BUS;
using DAL.Entities;
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
    public partial class frmUngLuong : Form
    {
        private UngLuongBUS ungLuongBUS;

        public frmUngLuong()
        {
            InitializeComponent();
            ungLuongBUS = new UngLuongBUS();

        }



        private void frmUngLuong_Load(object sender, EventArgs e)
        {
            LoadData();
            if (dgvUngLuong.Columns["Id"] != null)
            {
                dgvUngLuong.Columns["Id"].Visible = false;
            }
            if (dgvUngLuong.Columns["NhanVien"] != null)
            {
                dgvUngLuong.Columns["NhanVien"].Visible = false;
            }

            txtHoTen.ReadOnly = true;
            txtPhongBan.ReadOnly = true;


        }
        private void LoadData()
        {
            dgvUngLuong.DataSource = ungLuongBUS.LayDanhSachUngLuong();

            // Kiểm tra cột trước khi đặt HeaderText
            if (dgvUngLuong.Columns["MaNhanVien"] != null)
            {
                dgvUngLuong.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            }
            if (dgvUngLuong.Columns["HoTen"] != null)
            {
                dgvUngLuong.Columns["HoTen"].HeaderText = "Họ Tên";
            }
            if (dgvUngLuong.Columns["PhongBan"] != null)
            {
                dgvUngLuong.Columns["PhongBan"].HeaderText = "Phòng Ban";
            }
            if (dgvUngLuong.Columns["NgayUng"] != null)
            {
                dgvUngLuong.Columns["NgayUng"].HeaderText = "Ngày Ứng";
            }
            if (dgvUngLuong.Columns["SoTienUng"] != null)
            {
                dgvUngLuong.Columns["SoTienUng"].HeaderText = "Số Tiền Ứng";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                UngLuong ungLuong = new UngLuong
                {
                    MaNhanVien = int.Parse(txtMaNhanVien.Text),
                    NgayUng = dtpNgayUng.Value,
                    SoTienUng = decimal.Parse(txtSoTienUng.Text)
                };
                ungLuongBUS.ThemUngLuong(ungLuong);
                LoadData();
                MessageBox.Show("Thêm ứng lương thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm ứng lương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvUngLuong.CurrentRow != null && dgvUngLuong.CurrentRow.Cells["Id"] != null && dgvUngLuong.CurrentRow.Cells["Id"].Value != null)
            {
                try
                {
                    int id = (int)dgvUngLuong.CurrentRow.Cells["Id"].Value;

                    UngLuong ungLuong = new UngLuong
                    {
                        Id = id,
                        MaNhanVien = int.Parse(txtMaNhanVien.Text),
                        NgayUng = dtpNgayUng.Value,
                        SoTienUng = decimal.Parse(txtSoTienUng.Text)
                    };

                    ungLuongBUS.SuaUngLuong(ungLuong);
                    LoadData();
                    MessageBox.Show("Sửa ứng lương thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi sửa ứng lương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng hợp lệ để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvUngLuong.CurrentRow != null && dgvUngLuong.CurrentRow.Cells["Id"] != null && dgvUngLuong.CurrentRow.Cells["Id"].Value != null)
            {
                try
                {
                    int id = (int)dgvUngLuong.CurrentRow.Cells["Id"].Value;

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ungLuongBUS.XoaUngLuong(id);
                        LoadData();
                        MessageBox.Show("Xóa ứng lương thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa ứng lương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng hợp lệ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvUngLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUngLuong.Rows[e.RowIndex];

                if (row.Cells["MaNhanVien"] != null && row.Cells["MaNhanVien"].Value != null)
                {
                    txtMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString();
                }
                if (row.Cells["HoTen"] != null && row.Cells["HoTen"].Value != null)
                {
                    txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                }
                if (row.Cells["PhongBan"] != null && row.Cells["PhongBan"].Value != null)
                {
                    txtPhongBan.Text = row.Cells["PhongBan"].Value.ToString();
                }
                if (row.Cells["NgayUng"] != null && row.Cells["NgayUng"].Value != null)
                {
                    dtpNgayUng.Value = Convert.ToDateTime(row.Cells["NgayUng"].Value);
                }
                if (row.Cells["SoTienUng"] != null && row.Cells["SoTienUng"].Value != null)
                {
                    txtSoTienUng.Text = row.Cells["SoTienUng"].Value.ToString();
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimNhanVien_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower(); // Đưa từ khóa tìm kiếm về chữ thường

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                // Thực hiện tìm kiếm không phân biệt hoa thường dựa trên Mã Nhân Viên hoặc Họ Tên
                var ketQuaTimKiem = ungLuongBUS.LayDanhSachUngLuong()
                    .Where(ul => ul.MaNhanVien.ToString().ToLower().Contains(tuKhoa) ||
                                 (!string.IsNullOrEmpty(ul.HoTen) && ul.HoTen.ToLower().Contains(tuKhoa)))
                    .ToList();

                if (ketQuaTimKiem.Count > 0)
                {
                    dgvUngLuong.DataSource = ketQuaTimKiem;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvUngLuong.DataSource = null; // Không có kết quả thì clear bảng
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
