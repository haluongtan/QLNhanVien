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
    public partial class frmQuanLyTk : Form
    {
        private UserBUS UserBUS;
        public frmQuanLyTk()
        {
            InitializeComponent();
            UserBUS = new UserBUS();
        }

        private void frmQuanLyTk_Load(object sender, EventArgs e)
        {
            LoadTaiKhoanData();
            dgvTaiKhoan.Columns["UserId"].Visible = false;

        }
        private void LoadTaiKhoanData()
        {
            var danhSachTaiKhoan = UserBUS.LayDanhSachTaiKhoan();
            dgvTaiKhoan.DataSource = danhSachTaiKhoan;

            // Cài đặt lại header text của các cột nếu dữ liệu đã có
            dgvTaiKhoan.Columns["Username"].HeaderText = "Tên đăng nhập";
            dgvTaiKhoan.Columns["Password"].HeaderText = "Mật khẩu";
            dgvTaiKhoan.Columns["Role"].HeaderText = "Quyền";

            // Điều chỉnh kích thước cột tự động cho phù hợp với nội dung
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn từ DataGridView
                DataGridViewRow selectedRow = dgvTaiKhoan.Rows[e.RowIndex];

                // Gán giá trị của dòng được chọn vào các TextBox
                txtTenDN.Text = selectedRow.Cells["Username"].Value?.ToString() ?? string.Empty;
                txtMK.Text = selectedRow.Cells["Password"].Value?.ToString() ?? string.Empty;
                txtQuyen.Text = selectedRow.Cells["Role"].Value?.ToString() ?? string.Empty;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemTaiKhoan themTaiKhoanForm = new frmThemTaiKhoan();
            var result = themTaiKhoanForm.ShowDialog();

            // Nếu việc thêm thành công, cập nhật lại DataGridView
            if (result == DialogResult.OK)
            {
                LoadTaiKhoanData(); // Hàm này để tải lại dữ liệu tài khoản và cập nhật DataGridView
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenDN.Text))
            {
                string tenDangNhap = txtTenDN.Text.Trim();
                string matKhau = txtMK.Text.Trim();
                string quyen = txtQuyen.Text.Trim();

                // Kiểm tra xem quyền có hợp lệ không
                if (quyen != "admin" && quyen != "nhanvien")
                {
                    MessageBox.Show("Quyền không hợp lệ. Vui lòng chọn 'admin' hoặc 'nhanVien'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật thông tin tài khoản thông qua BUS
                Users taiKhoan = new Users
                {
                    Username = tenDangNhap,
                    Password = matKhau,
                    Role = quyen
                };

                UserBUS.SuaTaiKhoan(taiKhoan);

                // Hiển thị thông báo thành công và tải lại DataGridView
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTaiKhoanData(); // Hàm này để tải lại dữ liệu tài khoản và cập nhật DataGridView
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenDN.Text))
            {
                string tenDangNhap = txtTenDN.Text.Trim();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Xóa tài khoản thông qua BUS
                    UserBUS.XoaTaiKhoan(tenDangNhap);

                    // Hiển thị thông báo thành công và tải lại DataGridView
                    MessageBox.Show("Đã xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTaiKhoanData(); // Hàm này để tải lại dữ liệu tài khoản và cập nhật DataGridView
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
