using BUS;
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
    public partial class frmQuanLyLuong : Form
    {
        private LuongBUS luongBUS;

        public frmQuanLyLuong()
        {
            InitializeComponent();
            luongBUS = new LuongBUS();

        }

        private void frmQuanLyLuong_Load(object sender, EventArgs e)
        {
            LoadLuongData();

        }
        public void LoadLuongData()
        {
            var nhanVienData = luongBUS.LayDanhSachNhanVienChuaCoLuong();
            if (nhanVienData == null || !nhanVienData.Any())
            {
                MessageBox.Show("Không có dữ liệu nhân viên để hiển thị.");
                return;
            }

            dgvLuong.DataSource = nhanVienData;

            // Cài đặt lại header text của các cột nếu dữ liệu đã có
            if (dgvLuong.Columns.Contains("MaNhanVien"))
            {
                dgvLuong.Columns["MaLuong"].HeaderText = "Mã Lương";
                dgvLuong.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                dgvLuong.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
                dgvLuong.Columns["LuongCoBan"].HeaderText = "Lương Cơ Bản";
                dgvLuong.Columns["PhuCap"].HeaderText = "Phụ Cấp";
                dgvLuong.Columns["Thang"].HeaderText = "Tháng";
                dgvLuong.Columns["Nam"].HeaderText = "Năm";
            }

            dgvLuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void dgvLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLuong.Rows[e.RowIndex];

                // Gán giá trị từ DataGridView vào các TextBox
                txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNhanVien"].Value.ToString();
                txtLuongCoBan.Text = row.Cells["LuongCoBan"].Value.ToString();
                txtPhuCap.Text = row.Cells["PhuCap"].Value.ToString();
                txtThang.Text = row.Cells["Thang"].Value.ToString();
                txtNam.Text = row.Cells["Nam"].Value.ToString();
            }
        }

        private void btnThemLuong_Click(object sender, EventArgs e)
        {
            frmThemLuong themLuong = new frmThemLuong();
            themLuong.ShowDialog();
        }

        private void btnSuaLuong_Click(object sender, EventArgs e)
        {
            if (dgvLuong.CurrentRow != null && dgvLuong.CurrentRow.Index >= 0)
            {
                int maNhanVien = Convert.ToInt32(dgvLuong.CurrentRow.Cells["MaNhanVien"].Value);
                string tenNhanVien = dgvLuong.CurrentRow.Cells["TenNhanVien"].Value.ToString();
                decimal luongCoBan = Convert.ToDecimal(dgvLuong.CurrentRow.Cells["LuongCoBan"].Value);
                decimal phuCap = Convert.ToDecimal(dgvLuong.CurrentRow.Cells["PhuCap"].Value);
                int thang = Convert.ToInt32(dgvLuong.CurrentRow.Cells["Thang"].Value);
                int nam = Convert.ToInt32(dgvLuong.CurrentRow.Cells["Nam"].Value);

                frmSuaLuong frm = new frmSuaLuong(this, maNhanVien, tenNhanVien, luongCoBan, phuCap, thang, nam);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.");
            }
        }

        private void btnXoaLuong_Click(object sender, EventArgs e)
        {
            if (dgvLuong.CurrentRow != null)
            {
                int maLuong = Convert.ToInt32(dgvLuong.CurrentRow.Cells["MaLuong"].Value);
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa lương của nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    luongBUS.XoaLuong(maLuong);
                    LoadLuongData();
                    MessageBox.Show("Đã xóa thành công lương của nhân viên.", "Thành công");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa lương.", "Lỗi");
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close  ();
        }
    }
}
