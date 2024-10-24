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

namespace QLNhanVien
{
    public partial class frmThemLuong : Form
    {
        private LuongBUS luongBUS;

        public frmThemLuong()
        {
            InitializeComponent();
            luongBUS = new LuongBUS();

        }

        private void frmThemLuong_Load(object sender, EventArgs e)
        {
            LoadNhanVienChuaCoLuong();

        }
        private void LoadNhanVienChuaCoLuong()
        {
            dgvLuong.Columns.Clear();

            dgvLuong.Columns.Add("MaNhanVien", "Mã Nhân Viên");
            dgvLuong.Columns.Add("TenNhanVien", "Tên Nhân Viên");
            dgvLuong.Columns.Add("MaPhongBan", "Mã Phòng Ban");
            dgvLuong.Columns.Add("MaChucVu", "Mã Chức Vụ");

            var nhanVienChuaCL = luongBUS.LayDanhSachNhanVienChuaCL();

            foreach (var nv in nhanVienChuaCL)
            {
                dgvLuong.Rows.Add(nv.MaNhanVien, nv.HoTen, nv.MaPhongBan, nv.MaChucVu);
            }
        }




        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            err.Clear(); // Xóa lỗi trước đó

            // Kiểm tra các trường không để trống và chỉ chứa số
            if (string.IsNullOrEmpty(txtLuongCoBan.Text) || !decimal.TryParse(txtLuongCoBan.Text, out decimal luongCoBan))
            {
                err.SetError(txtLuongCoBan, "Vui lòng nhập lương cơ bản và chỉ nhập số.");
                return;
            }

            if (string.IsNullOrEmpty(txtPhuCap.Text) || !decimal.TryParse(txtPhuCap.Text, out decimal phuCap))
            {
                err.SetError(txtPhuCap, "Vui lòng nhập phụ cấp và chỉ nhập số.");
                return;
            }

            if (string.IsNullOrEmpty(txtThang.Text) || !int.TryParse(txtThang.Text, out int thang))
            {
                err.SetError(txtThang, "Vui lòng nhập tháng và chỉ nhập số.");
                return;
            }

            if (string.IsNullOrEmpty(txtNam.Text) || !int.TryParse(txtNam.Text, out int nam))
            {
                err.SetError(txtNam, "Vui lòng nhập năm và chỉ nhập số.");
                return;
            }

            // Lấy mã nhân viên và thông tin lương từ các TextBox
            int maNhanVien = int.Parse(txtMaNV.Text);

            // Tạo bản ghi lương mới
            Luong luongMoi = new Luong
            {
                MaNhanVien = maNhanVien,
                LuongCoBan = luongCoBan,
                PhuCap = phuCap,
                Thang = thang,
                Nam = nam
            };

            // Thêm bản ghi lương mới thông qua BUS
            luongBUS.ThemLuong(luongMoi);

            // Xóa nhân viên khỏi DataGridView sau khi thêm lương
            foreach (DataGridViewRow row in dgvLuong.Rows)
            {
                if (row.Cells["MaNhanVien"].Value.ToString() == maNhanVien.ToString())
                {
                    dgvLuong.Rows.Remove(row);
                    break;
                }
            }

            // Cập nhật frmQuanLyLuong để hiển thị nhân viên vừa thêm lương
            frmQuanLyLuong quanLyLuong = Application.OpenForms.OfType<frmQuanLyLuong>().FirstOrDefault();
            if (quanLyLuong != null)
            {
                quanLyLuong.LoadLuongData();
            }

            // Thông báo thành công
            MessageBox.Show("Đã thêm lương thành công cho nhân viên.");
        
        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLuong.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNhanVien"].Value.ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLuongCoBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                err.SetError(txtLuongCoBan, "Chỉ được nhập số.");
            }
            else
            {
                err.SetError(txtLuongCoBan, "");
            }
        }

        private void txtPhuCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                err.SetError(txtPhuCap, "Chỉ được nhập số.");
            }
            else
            {
                err.SetError(txtPhuCap, "");
            }
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                err.SetError(txtThang, "Chỉ được nhập số.");
            }
            else
            {
                err.SetError(txtThang, "");
            }
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                err.SetError(txtNam, "Chỉ được nhập số.");
            }
            else
            {
                err.SetError(txtNam, "");
            }
        }
    }
}
