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
    public partial class frmSuaNhanVien : Form
    {
        private frmMain formChinh; 
        private Model1 dbContext;
        private NhanVien nhanVien;

        public frmSuaNhanVien(frmMain form1, Model1 context, NhanVien nv)
        {
            InitializeComponent();
            formChinh = form1;
            dbContext = context;
            nhanVien = nv;
            err = new ErrorProvider(); 

        }

        private void frmSuaNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = nhanVien.MaNhanVien.ToString();
            txtHoTen.Text = nhanVien.HoTen;
            dtpNgaySinh.Value = nhanVien.NgaySinh ?? DateTime.Now;
            if (nhanVien.GioiTinh == "Nam")
                rbNam.Checked = true;
            else
                rbNu.Checked = true;
            txtSDT.Text = nhanVien.SDT;
            txtDiaChi.Text = nhanVien.DiaChi;
            txtMaPhongBan.Text = nhanVien.MaPhongBan?.ToString();
            txtMaChucVu.Text = nhanVien.MaChucVu?.ToString();
            dtpNgayVaoLam.Value = nhanVien.NgayVaoLam ?? DateTime.Now;
            txtEmail.Text = nhanVien.Email;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            nhanVien.HoTen = txtHoTen.Text;
            nhanVien.NgaySinh = dtpNgaySinh.Value;
            nhanVien.GioiTinh = rbNam.Checked ? "Nam" : "Nữ";
            nhanVien.SDT = txtSDT.Text;
            nhanVien.DiaChi = txtDiaChi.Text;
            nhanVien.MaPhongBan = int.TryParse(txtMaPhongBan.Text, out int maPhongBan) ? (int?)maPhongBan : null;
            nhanVien.MaChucVu = int.TryParse(txtMaChucVu.Text, out int maChucVu) ? (int?)maChucVu : null;
            nhanVien.NgayVaoLam = dtpNgayVaoLam.Value;
            nhanVien.Email = txtEmail.Text;

            dbContext.SaveChanges();
            MessageBox.Show("Cập nhật thông tin nhân viên thành công!");

            formChinh.LoadData();

            this.Close();
        }
        private bool ValidateInputs()
        {
            bool isValid = true;
            err.Clear(); 

            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                err.SetError(txtHoTen, "Vui lòng nhập họ tên.");
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                err.SetError(txtSDT, "Vui lòng nhập số điện thoại.");
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                err.SetError(txtDiaChi, "Vui lòng nhập địa chỉ.");
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtMaPhongBan.Text))
            {
                err.SetError(txtMaPhongBan, "Vui lòng nhập mã phòng ban.");
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtMaChucVu.Text))
            {
                err.SetError(txtMaChucVu, "Vui lòng nhập mã chức vụ.");
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                err.SetError(txtEmail, "Vui lòng nhập email.");
                isValid = false;
            }

            return isValid;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                err.SetError(txtHoTen, "Chỉ được nhập ký tự chữ.");
            }
            else
            {
                err.SetError(txtHoTen, "");  
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                err.SetError(txtSDT, "Chỉ được nhập ký tự số.");
            }
            else
            {
                err.SetError(txtSDT, ""); 
            }
        }
    }
}
