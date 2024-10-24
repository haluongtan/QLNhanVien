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
    public partial class frmThemTaiKhoan : Form
    {
        private UserBUS taiKhoanBUS;

        public frmThemTaiKhoan()
        {
            InitializeComponent();
            taiKhoanBUS = new UserBUS();
            LoadQuyenComboBox();
        }
        private void LoadQuyenComboBox()
        {
            cmbQuyen.Items.Add("admin");
            cmbQuyen.Items.Add("nhanVien");
            cmbQuyen.SelectedIndex = 0; 
        }
        private void frmThemTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDN.Text) || string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Users taiKhoanMoi = new Users
            {
                Username = txtTenDN.Text.Trim(),
                Password = txtMK.Text.Trim(),
                Role = cmbQuyen.SelectedItem.ToString()
            };

            taiKhoanBUS.ThemTaiKhoan(taiKhoanMoi);
            MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
