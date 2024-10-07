using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanVien
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenTK.Text;
            string password = txtMK.Text;

            using (var dbContext = new Model1())
            {
                // Tìm người dùng theo username và password
                var user = dbContext.Users
                    .FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    // Kiểm tra loại tài khoản
                    if (user.Role == "admin")
                    {
                        MessageBox.Show("Đăng nhập thành công với quyền Admin.");

                        // Mở form quản lý nhân sự với quyền admin
                        frmQuanLyNhanSu frmAdmin = new frmQuanLyNhanSu();
                        frmAdmin.Show();
                        this.Hide();  // Ẩn form đăng nhập
                    }
                    else if (user.Role == "nhanvien")
                    {
                        MessageBox.Show("Đăng nhập thành công với quyền Nhân viên.");

                        // Mở form chấm công với quyền hạn của nhân viên (chỉ xem)
                        frmChamCong frmNhanVien = new frmChamCong();
                        frmNhanVien.ApplyRoleRestrictions("nhanvien"); // Gọi hàm áp dụng quyền chỉ xem cho nhân viên
                        frmNhanVien.Show();
                        this.Hide();  // Ẩn form đăng nhập
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
