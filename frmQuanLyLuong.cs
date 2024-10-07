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
        public frmQuanLyLuong()
        {
            InitializeComponent();
        }

        private void frmQuanLyLuong_Load(object sender, EventArgs e)
        {
            LoadLuongData();

        }
        public void LoadLuongData()
        {
            using (var dbContext = new Model1())
            {
                // Lấy dữ liệu bảng Luong và liên kết với bảng NhanVien để thêm cột TenNhanVien
                var luongData = (from l in dbContext.Luong
                                 join nv in dbContext.NhanVien on l.MaNhanVien equals nv.MaNhanVien
                                 select new
                                 {
                                     l.MaLuong,
                                     l.MaNhanVien,
                                     TenNhanVien = nv.HoTen,
                                     l.LuongCoBan,
                                     l.PhuCap,
                                     l.Thang,
                                     l.Nam
                                 }).ToList();

                // Hiển thị dữ liệu lên DataGridView
                dgvLuong.DataSource = luongData;

                // Đặt tên cho các cột hiển thị
                dgvLuong.Columns["MaLuong"].HeaderText = "Mã Lương";
                dgvLuong.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                dgvLuong.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
                dgvLuong.Columns["LuongCoBan"].HeaderText = "Lương Cơ Bản";
                dgvLuong.Columns["PhuCap"].HeaderText = "Phụ Cấp";
                dgvLuong.Columns["Thang"].HeaderText = "Tháng";
                dgvLuong.Columns["Nam"].HeaderText = "Năm";

                // Tùy chọn căn chỉnh kích thước cột
                dgvLuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
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
            if (dgvLuong.CurrentRow != null && dgvLuong.CurrentRow.Index >= 0)
            {
                // Lấy mã nhân viên và mã lương từ hàng đã chọn
                int maLuong = Convert.ToInt32(dgvLuong.CurrentRow.Cells["MaLuong"].Value);
                int maNhanVien = Convert.ToInt32(dgvLuong.CurrentRow.Cells["MaNhanVien"].Value);

                // Hiển thị thông báo xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa lương của nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Tiến hành xóa trong cơ sở dữ liệu
                    using (var dbContext = new Model1())
                    {
                        // Tìm bản ghi lương cần xóa
                        var luongToDelete = dbContext.Luong.FirstOrDefault(l => l.MaLuong == maLuong);

                        if (luongToDelete != null)
                        {
                            // Xóa bản ghi
                            dbContext.Luong.Remove(luongToDelete);
                            dbContext.SaveChanges();

                            // Tải lại dữ liệu sau khi xóa
                            LoadLuongData();

                            MessageBox.Show("Đã xóa thành công lương của nhân viên.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy lương của nhân viên này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa lương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
