using BUS;
using QLNhanVien;
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
    public partial class frmLogin : Form
    {
        private UserBUS userBUS;

        public frmLogin()
        {
            InitializeComponent();
            userBUS = new UserBUS();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenTK.Text.Trim();
            string password = txtMK.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = userBUS.CheckUserLogin(username, password);

            if (user != null)
            {
                if (user.Role == "admin")
                {
                    frmQuanLyNhanSu frmAdmin = new frmQuanLyNhanSu();
                    frmAdmin.Show();
                    this.Hide();
                }
                else if (user.Role == "nhanvien")
                {
                    frmChamCong frmNhanVien = new frmChamCong();
                    frmNhanVien.ApplyRoleRestrictions("nhanvien");
                    frmNhanVien.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
