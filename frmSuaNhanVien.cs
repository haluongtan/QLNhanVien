using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanVien
{
    public partial class frmSuaNhanVien : Form
    {
        private NhanVienBUS nhanVienBUS = new NhanVienBUS();
        private int maNhanVien;
        private NhanVien nhanVien;
        private frmMain formChinh;



        public frmSuaNhanVien( frmMain formChinh,int maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
            this.formChinh = formChinh;
            err = new ErrorProvider(); 

        }

        private void frmSuaNhanVien_Load(object sender, EventArgs e)
        {
            NhanVien nv = nhanVienBUS.LayNhanVienTheoMa(maNhanVien);
            if (nv == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            nhanVien = nv;

            txtMaNV.Text = nv.MaNhanVien.ToString();
            txtHoTen.Text = nv.HoTen;
            dtpNgaySinh.Value = nv.NgaySinh ?? DateTime.Now;
            if (nv.GioiTinh == "Nam")
                rbNam.Checked = true;
            else
                rbNu.Checked = true;
            txtSDT.Text = nv.SDT;
            txtDiaChi.Text = nv.DiaChi;
            txtMaPhongBan.Text = nv.MaPhongBan?.ToString();
            txtMaChucVu.Text = nv.MaChucVu?.ToString();
            dtpNgayVaoLam.Value = nv.NgayVaoLam ?? DateTime.Now;
            txtEmail.Text = nv.Email;

            if (!string.IsNullOrEmpty(nv.AvatarPath) && System.IO.File.Exists(nv.AvatarPath))
            {
                ptrAvatar.Image = Image.FromFile(nv.AvatarPath);
                ptrAvatar.Tag = nv.AvatarPath; // Lưu đường dẫn vào Tag
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            // Cập nhật lại các thuộc tính của nhân viên
            nhanVien.HoTen = txtHoTen.Text;
            nhanVien.NgaySinh = dtpNgaySinh.Value;
            nhanVien.GioiTinh = rbNam.Checked ? "Nam" : "Nữ";
            nhanVien.SDT = txtSDT.Text;
            nhanVien.DiaChi = txtDiaChi.Text;
            nhanVien.MaPhongBan = int.TryParse(txtMaPhongBan.Text, out int maPhongBan) ? (int?)maPhongBan : null;
            nhanVien.MaChucVu = int.TryParse(txtMaChucVu.Text, out int maChucVu) ? (int?)maChucVu : null;
            nhanVien.NgayVaoLam = dtpNgayVaoLam.Value;
            nhanVien.Email = txtEmail.Text;
            nhanVien.AvatarPath = ptrAvatar.Tag?.ToString();

            nhanVienBUS.SuaNhanVien(nhanVien);
            MessageBox.Show("Cập nhật thông tin nhân viên thành công!");

            // Gọi hàm cập nhật dữ liệu trên DataGridView
            formChinh.CapNhatNhanVien(nhanVien);

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

        private void btnThemHinhAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ptrAvatar.Image = Image.FromFile(openFileDialog.FileName);
                    ptrAvatar.Tag = openFileDialog.FileName; // Lưu đường dẫn ảnh vào Tag của PictureBox
                }
            }
        }

        private void ptrAvatar_Click(object sender, EventArgs e)
        {

        }
    }
}
