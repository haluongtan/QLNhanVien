using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanVien
{
    public partial class frmMain : Form
    {
        private Model1 dbContext {  get; set; }

        public frmMain()
        {
            InitializeComponent();
            dbContext = new Model1();  // Khởi tạo dbContext

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvNhanVien.Columns["Luong"].Visible = false;
            dgvNhanVien.Columns["ChucVu"].Visible = false;
            dgvNhanVien.Columns["PhongBan"].Visible = false;
        }
        public void LoadData()
        {
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var nhanVienList = dbContext.NhanVien.ToList();
            dgvNhanVien.DataSource = nhanVienList;

            if (dgvNhanVien.Rows.Count > 0)
            {
                dgvNhanVien.Rows[0].Selected = true;  
            }
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                // Kiểm tra null trước khi truy xuất giá trị của từng ô
                txtMaNV.Text = row.Cells["MaNhanVien"].Value != null ? row.Cells["MaNhanVien"].Value.ToString() : string.Empty;
                txtHoTen.Text = row.Cells["HoTen"].Value != null ? row.Cells["HoTen"].Value.ToString() : string.Empty;

                if (row.Cells["NgaySinh"].Value != null)
                {
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                }
                else
                {
                    dtpNgaySinh.Value = DateTime.Now;  // Giá trị mặc định nếu null
                }

                if (row.Cells["GioiTinh"].Value != null && row.Cells["GioiTinh"].Value.ToString() == "Nam")
                {
                    rbNam.Checked = true;
                }
                else
                {
                    rbNu.Checked = true;
                }

                txtSDT.Text = row.Cells["SDT"].Value != null ? row.Cells["SDT"].Value.ToString() : string.Empty;
                txtDiaChi.Text = row.Cells["DiaChi"].Value != null ? row.Cells["DiaChi"].Value.ToString() : string.Empty;
                txtMaPhongBan.Text = row.Cells["MaPhongBan"].Value != null ? row.Cells["MaPhongBan"].Value.ToString() : string.Empty;
                txtMaChucVu.Text = row.Cells["MaChucVu"].Value != null ? row.Cells["MaChucVu"].Value.ToString() : string.Empty;

                if (row.Cells["NgayVaoLam"].Value != null)
                {
                    dtpNgayVaoLam.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);
                }
                else
                {
                    dtpNgayVaoLam.Value = DateTime.Now;  // Giá trị mặc định nếu null
                }

                txtEmail.Text = row.Cells["Email"].Value != null ? row.Cells["Email"].Value.ToString() : string.Empty;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaNV.Text))
            {
                int maNhanVien = int.Parse(txtMaNV.Text);

                var nhanVienToDelete = dbContext.NhanVien.SingleOrDefault(nv => nv.MaNhanVien == maNhanVien);

                if (nhanVienToDelete != null)
                {
                    dbContext.NhanVien.Remove(nhanVienToDelete);
                    dbContext.SaveChanges();
                    MessageBox.Show("Đã xóa nhân viên thành công!");

                    // Refresh the DataGridView
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên để xóa.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemNhanVien ThemNV = new frmThemNhanVien(this, dbContext);

            // Mở form thêm nhân viên và kiểm tra kết quả trả về
            var result = ThemNV.ShowDialog();

            // Chỉ mở form ThemLuong nếu nhân viên mới được thêm thành công
            if (result == DialogResult.OK)
            {
                var nhanVienMoi = dbContext.NhanVien.ToList().LastOrDefault();

                if (nhanVienMoi != null)
                {
                    // Mở form chấm công và thêm nhân viên mới vào bảng chấm công
                    frmChamCong frmChamCong = Application.OpenForms.OfType<frmChamCong>().FirstOrDefault();
                    if (frmChamCong != null)
                    {
                        frmChamCong.AddNhanVienToChamCong(nhanVienMoi.MaNhanVien, nhanVienMoi.HoTen);
                    }

                    frmThemLuong formThemLuong = new frmThemLuong();
                    formThemLuong.AddNhanVienToGrid(nhanVienMoi.MaNhanVien, nhanVienMoi.HoTen);
                    formThemLuong.Show();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null) // Kiểm tra nếu có dòng hiện tại được chọn
            {
                int maNhanVien = int.Parse(dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString());

                // Tìm nhân viên trong dbContext
                var nhanVien = dbContext.NhanVien.SingleOrDefault(nv => nv.MaNhanVien == maNhanVien);

                if (nhanVien != null)
                {
                    // Mở form sửa nhân viên và truyền nhân viên cần sửa
                    frmSuaNhanVien suaNV = new frmSuaNhanVien(this, dbContext, nhanVien);
                    suaNV.ShowDialog();  // Hiển thị form sửa
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên để sửa.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                var ketQuaTimKiem = dbContext.NhanVien
                    .Where(nv => nv.MaNhanVien.ToString().Contains(tuKhoa) ||
                                 nv.HoTen.Contains(tuKhoa) ||
                                 nv.SDT.Contains(tuKhoa))
                    .ToList();

                dgvNhanVien.DataSource = ketQuaTimKiem;

                if (ketQuaTimKiem.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào phù hợp.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
            }
        }


    }
}
