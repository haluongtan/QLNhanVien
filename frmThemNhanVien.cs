using BUS;
using DAL.Entities;
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

namespace QLNhanVien
{
    public partial class frmThemNhanVien : Form
    {
        private NhanVienBUS nhanVienBUS = new NhanVienBUS();


        public frmThemNhanVien()
        {
            InitializeComponent();

            err = new ErrorProvider();


        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;

                NhanVien nv = new NhanVien()
                {
                    MaNhanVien = int.Parse(txtMaNV.Text),
                    HoTen = txtHoTen.Text,
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = rbNam.Checked ? "Nam" : "Nữ",
                    SDT = txtSDT.Text,
                    DiaChi = txtDiaChi.Text,
                    MaPhongBan = int.Parse(txtMaPhongBan.Text),
                    MaChucVu = int.Parse(txtMaChucVu.Text),
                    NgayVaoLam = dtpNgayVaoLam.Value,
                    Email = txtEmail.Text,
                    AvatarPath = ptrAvatar.Tag?.ToString()
                };

                nhanVienBUS.ThemNhanVien(nv);
                MessageBox.Show("Thêm nhân viên thành công!");
                this.DialogResult = DialogResult.OK; // Trả về OK để form chính biết là đã thêm thành công
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        private bool ValidateInputs()
        {
            bool isValid = true;
            err.Clear(); // Xóa tất cả thông báo lỗi trước đó

            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                err.SetError(txtMaNV, "Vui lòng nhập mã nhân viên.");
                isValid = false;
            }

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

        private void ClearForm()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            rbNam.Checked = true;
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMaPhongBan.Clear();
            txtMaChucVu.Clear();
            dtpNgayVaoLam.Value = DateTime.Now;
            txtEmail.Clear();
            err.Clear();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     

        private void frmThemNhanVien_Load(object sender, EventArgs e)
        {
            rbNam.Checked = true;
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

        private void pnThongTin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ptrAvatar_Click(object sender, EventArgs e)
        {

        }

        private void btnThemHinhAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ptrAvatar.Image = Image.FromFile(openFileDialog.FileName);
                    ptrAvatar.Tag = openFileDialog.FileName;
                }
            }
        }
    }
}
