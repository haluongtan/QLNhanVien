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
        private frmMain formChinh;
        private Model1 dbContext;

        public frmThemNhanVien(frmMain form1, Model1 context)
        {
            InitializeComponent();
            formChinh = form1;
            dbContext = context;
            err = new ErrorProvider();


        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem các ô nhập liệu có hợp lệ không
                if (!ValidateInputs()) return;

                // Tạo một đối tượng NhanVien mới
                NhanVien nv = new NhanVien()
                {
                    MaNhanVien = int.Parse(txtMaNV.Text),
                    HoTen = txtHoTen.Text,
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = rbNam.Checked ? "Nam" : "Nữ",
                    SDT = txtSDT.Text,
                    DiaChi = txtDiaChi.Text,
                    MaPhongBan = string.IsNullOrEmpty(txtMaPhongBan.Text) ? (int?)null : int.Parse(txtMaPhongBan.Text),
                    MaChucVu = string.IsNullOrEmpty(txtMaChucVu.Text) ? (int?)null : int.Parse(txtMaChucVu.Text),
                    NgayVaoLam = dtpNgayVaoLam.Value,
                    Email = txtEmail.Text
                };

                // Thêm nhân viên vào DbContext và lưu vào cơ sở dữ liệu
                dbContext.NhanVien.Add(nv);
                dbContext.SaveChanges();

                MessageBox.Show("Thêm nhân viên thành công!");

                // Cập nhật lại DataGridView trong form chính
                formChinh.LoadData();

                // Xóa lỗi và thông tin nhập
                ClearForm();
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
            // Xóa trắng các ô nhập liệu sau khi thêm nhân viên
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
    }
}
