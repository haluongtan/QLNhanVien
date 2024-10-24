using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Entities;

namespace QLNhanVien
{
    public partial class frmHopDong : Form
    {
        private HopDongBus hopDongBUS = new HopDongBus();

        public frmHopDong()
        {
            InitializeComponent();
        }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            RefreshGrid();

        }

        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHopDong.Rows[e.RowIndex];

                // Kiểm tra nếu cột tồn tại trước khi truy cập
                if (row.Cells["MaHopDong"] != null)
                {
                    txtMaHD.Text = row.Cells["MaHopDong"].Value.ToString();
                }
                if (row.Cells["MaNhanVien"] != null)
                {
                    txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                }
                if (row.Cells["TenNhanVien"] != null)
                {
                    txtTenNV.Text = row.Cells["TenNhanVien"].Value.ToString();
                }
                if (row.Cells["LoaiHopDong"] != null)
                {
                    txtLoaiHD.Text = row.Cells["LoaiHopDong"].Value.ToString();
                }
                if (row.Cells["NgayKy"] != null)
                {
                    dtpNgayDK.Value = Convert.ToDateTime(row.Cells["NgayKy"].Value);
                }
                if (row.Cells["NgayHetHan"] != null)
                {
                    dtpNgayHH.Value = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
                }
            }
        }
        public void RefreshGrid()
        {
            var hopDongData = hopDongBUS.LayDanhSachHopDong();
            dgvHopDong.DataSource = hopDongData;

            // Rename columns for display
            dgvHopDong.Columns["MaHopDong"].HeaderText = "Mã Hợp Đồng";
            dgvHopDong.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dgvHopDong.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
            dgvHopDong.Columns["LoaiHopDong"].HeaderText = "Loại Hợp Đồng";
            dgvHopDong.Columns["NgayKy"].HeaderText = "Ngày Ký";
            dgvHopDong.Columns["NgayHetHan"].HeaderText = "Ngày Hết Hạn";

            dgvHopDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemHopDong ThemHD = new frmThemHopDong();
            ThemHD.ShowDialog();
            RefreshGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (var dbContext = new Model1())
            {
                int maHopDong = int.Parse(txtMaHD.Text);

                var hopDongToUpdate = dbContext.HopDong.FirstOrDefault(hd => hd.MaHopDong == maHopDong);

                if (hopDongToUpdate != null)
                {
                    // Cập nhật thông tin từ các TextBox và DateTimePicker
                    hopDongToUpdate.LoaiHopDong = txtLoaiHD.Text;
                    hopDongToUpdate.NgayKy = dtpNgayDK.Value;
                    hopDongToUpdate.NgayHetHan = dtpNgayHH.Value;

                    // Lưu thay đổi vào database
                    dbContext.SaveChanges();

                    // Thông báo thành công
                    MessageBox.Show("Sửa hợp đồng thành công!");

                    // Refresh lại DataGridView
                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hợp đồng để sửa!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                using (var dbContext = new Model1())
                {
                    // Lấy Mã Hợp Đồng từ textbox
                    int maHopDong = int.Parse(txtMaHD.Text);

                    // Tìm hợp đồng cần xóa dựa vào Mã Hợp Đồng
                    var hopDongToDelete = dbContext.HopDong.FirstOrDefault(hd => hd.MaHopDong == maHopDong);

                    if (hopDongToDelete != null)
                    {
                        // Xóa hợp đồng khỏi context
                        dbContext.HopDong.Remove(hopDongToDelete);

                        // Lưu thay đổi vào database
                        dbContext.SaveChanges();

                        // Thông báo thành công
                        MessageBox.Show("Xóa hợp đồng thành công!");

                        // Xóa các trường text để người dùng dễ nhìn thấy là hợp đồng đã bị xóa
                        ClearFields();

                        // Refresh lại DataGridView
                        RefreshGrid();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hợp đồng để xóa!");
                    }
                }
            }
        }
        private void ClearFields()
        {
            txtMaHD.Clear();
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtLoaiHD.Clear();
            dtpNgayDK.Value = DateTime.Now;
            dtpNgayHH.Value = DateTime.Now;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                var ketQuaTimKiem = hopDongBUS.TimKiemHopDong(tuKhoa);
                dgvHopDong.DataSource = ketQuaTimKiem;

                if (ketQuaTimKiem.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào phù hợp.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
