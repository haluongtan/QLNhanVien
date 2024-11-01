using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
        private NhanVienBUS nhanVienBUS = new NhanVienBUS();
        private Model1 dbContext;
        public frmMain()
        {
            InitializeComponent();
            dbContext = new Model1();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvNhanVien.Columns["Luong"].Visible = false;
            dgvNhanVien.Columns["ChucVu"].Visible = false;
            dgvNhanVien.Columns["PhongBan"].Visible = false;
            dgvNhanVien.Columns["MaChamCong"].Visible = false;
            dgvNhanVien.Columns["ChamCong"].Visible = false;

        }
        public void LoadData()
        {
            var nhanVienList = nhanVienBUS.LayDanhSachNhanVien();
            dgvNhanVien.DataSource = nhanVienList;

            if (dgvNhanVien.Columns["AvatarPath"] == null)
            {
                dgvNhanVien.Columns.Add("AvatarPath", "Avatar Path");
            }

            dgvNhanVien.Columns["AvatarPath"].Visible = false; 

            if (dgvNhanVien.Rows.Count > 0)
            {
                dgvNhanVien.Rows[0].Selected = true;
            }

            dgvNhanVien.Refresh();
        }
        public void CapNhatNhanVien(NhanVien nhanVien)
        {
            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                if (int.Parse(row.Cells["MaNhanVien"].Value.ToString()) == nhanVien.MaNhanVien)
                {
                    row.Cells["HoTen"].Value = nhanVien.HoTen;
                    row.Cells["NgaySinh"].Value = nhanVien.NgaySinh;
                    row.Cells["GioiTinh"].Value = nhanVien.GioiTinh;
                    row.Cells["SDT"].Value = nhanVien.SDT;
                    row.Cells["DiaChi"].Value = nhanVien.DiaChi;
                    row.Cells["MaPhongBan"].Value = nhanVien.MaPhongBan;
                    row.Cells["MaChucVu"].Value = nhanVien.MaChucVu;
                    row.Cells["NgayVaoLam"].Value = nhanVien.NgayVaoLam;
                    row.Cells["Email"].Value = nhanVien.Email;
                    row.Cells["AvatarPath"].Value = nhanVien.AvatarPath;

                    // Nếu muốn cập nhật lại ảnh trên form chính
                    if (row.Selected && ptrAvatar != null)
                    {
                        if (!string.IsNullOrEmpty(nhanVien.AvatarPath) && System.IO.File.Exists(nhanVien.AvatarPath))
                        {
                            ptrAvatar.Image = Image.FromFile(nhanVien.AvatarPath);
                        }
                        else
                        {
                            ptrAvatar.Image = null;
                        }
                    }
                    break;
                }
            }
        }


        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng hàng được chọn là hợp lệ
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells["MaNhanVien"].Value?.ToString() ?? string.Empty;
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? string.Empty;

                if (row.Cells["NgaySinh"].Value != null)
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                else
                    dtpNgaySinh.Value = DateTime.Now;

                rbNam.Checked = row.Cells["GioiTinh"].Value?.ToString() == "Nam";
                rbNu.Checked = row.Cells["GioiTinh"].Value?.ToString() == "Nữ";

                txtSDT.Text = row.Cells["SDT"].Value?.ToString() ?? string.Empty;
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? string.Empty;
                txtMaPhongBan.Text = row.Cells["MaPhongBan"].Value?.ToString() ?? string.Empty;
                txtMaChucVu.Text = row.Cells["MaChucVu"].Value?.ToString() ?? string.Empty;

                if (row.Cells["NgayVaoLam"].Value != null)
                    dtpNgayVaoLam.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);
                else
                    dtpNgayVaoLam.Value = DateTime.Now;

                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;

                // Hiển thị ảnh đại diện nếu có
                if (row.Cells["AvatarPath"].Value != null)
                {
                    string avatarPath = row.Cells["AvatarPath"].Value.ToString();
                    if (System.IO.File.Exists(avatarPath))
                    {
                        ptrAvatar.Image = Image.FromFile(avatarPath);
                    }
                    else
                    {
                        ptrAvatar.Image = null; // Nếu không tìm thấy ảnh, để trống PictureBox
                    }
                }
                else
                {
                    ptrAvatar.Image = null; // Nếu không có đường dẫn ảnh, để trống PictureBox
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaNV.Text))
            {
                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                // Nếu người dùng chọn Yes, thực hiện xóa
                if (result == DialogResult.Yes)
                {
                    int maNhanVien = int.Parse(txtMaNV.Text);
                    nhanVienBUS.XoaNhanVien(maNhanVien);
                    MessageBox.Show("Đã xóa nhân viên thành công!");
                    LoadData(); // Refresh lại DataGridView
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemNhanVien themNV = new frmThemNhanVien();
            var result = themNV.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadData();
                var nhanVienMoi = dbContext.NhanVien.ToList().LastOrDefault(); 

                if (nhanVienMoi != null)
                {
                    // Mở form chấm công và thêm nhân viên mới vào bảng chấm công
                    frmChamCong frmChamCong = Application.OpenForms.OfType<frmChamCong>().FirstOrDefault();
                    if (frmChamCong != null)
                    {
                        frmChamCong.AddNhanVienToChamCong(nhanVienMoi.MaNhanVien, nhanVienMoi.HoTen);
                    }
                   
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null) // Kiểm tra nếu có dòng hiện tại được chọn
            {
                int maNhanVien = int.Parse(dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString());
                var nhanVien = dbContext.NhanVien.SingleOrDefault(nv => nv.MaNhanVien == maNhanVien);

                // Mở form sửa nhân viên và truyền form chính vào
                frmSuaNhanVien suaNV = new frmSuaNhanVien(this, maNhanVien);
                suaNV.ShowDialog();  // Hiển thị form sửa
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
                var ketQuaTimKiem = nhanVienBUS.TimKiemNhanVien(tuKhoa);
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

        private void ptrAvatar_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnThongTin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
