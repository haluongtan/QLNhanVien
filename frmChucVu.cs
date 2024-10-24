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
    public partial class frmChucVu : Form
    {
        private ChucVuBUS chucVuBUS = new ChucVuBUS();



        public frmChucVu()
        {
            InitializeComponent();

        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {

            LoadData();
            cmbChucVu.SelectedIndexChanged += cmbChucVu_SelectedIndexChanged;

        }

        private void LoadData()
        {
            var chucVus = chucVuBUS.LayDanhSachChucVu();
            cmbChucVu.DataSource = chucVus;
            cmbChucVu.DisplayMember = "TenChucVu";
            cmbChucVu.ValueMember = "MaChucVu";

            dgvNhanVien.DataSource = null;
            dgvNhanVien.Columns.Clear();

            // Ẩn các cột không cần thiết
            if (dgvNhanVien.Columns["MaChamCong"] != null)
                dgvNhanVien.Columns["MaChamCong"].Visible = false;

            if (dgvNhanVien.Columns["ChamCong"] != null)
                dgvNhanVien.Columns["ChamCong"].Visible = false;

            if (dgvNhanVien.Columns["AvatarPath"] != null)
                dgvNhanVien.Columns["AvatarPath"].Visible = false;
        }

        private void cmbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChucVu.SelectedValue != null && cmbChucVu.SelectedValue is int)
            {
                int selectedChucVuId = (int)cmbChucVu.SelectedValue;

                // Lấy danh sách nhân viên theo mã chức vụ qua BUS
                var nhanVienList = chucVuBUS.LayDanhSachNhanVienTheoChucVu(selectedChucVuId);
                dgvNhanVien.DataSource = nhanVienList;

                // Hiển thị lương tương ứng với mã chức vụ
                var luong = chucVuBUS.LayLuongTheoChucVu(selectedChucVuId);
                txtLuong.Text = luong.HasValue ? luong.Value.ToString() : "N/A";

                if (nhanVienList.Count == 0)
                {
                    MessageBox.Show("Không có nhân viên nào trong chức vụ này.");
                }

                // Ẩn các cột không cần thiết nếu chúng tồn tại
                if (dgvNhanVien.Columns["Luong"] != null)
                    dgvNhanVien.Columns["Luong"].Visible = false;

                if (dgvNhanVien.Columns["ChucVu"] != null)
                    dgvNhanVien.Columns["ChucVu"].Visible = false;

                if (dgvNhanVien.Columns["PhongBan"] != null)
                    dgvNhanVien.Columns["PhongBan"].Visible = false;

                if (dgvNhanVien.Columns["MaChamCong"] != null)
                    dgvNhanVien.Columns["MaChamCong"].Visible = false;

                if (dgvNhanVien.Columns["ChamCong"] != null)
                    dgvNhanVien.Columns["ChamCong"].Visible = false;

                if (dgvNhanVien.Columns["AvatarPath"] != null)
                    dgvNhanVien.Columns["AvatarPath"].Visible = false;
            }

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

                if (row.Cells["GioiTinh"].Value?.ToString() == "Nam")
                {
                    rbNam.Checked = true;
                }
                else
                {
                    rbNu.Checked = true;
                }

                txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                txtChucVu.Text = row.Cells["MaChucVu"].Value?.ToString();

                // Hiển thị lương tương ứng với mã chức vụ của nhân viên
                int maChucVu = Convert.ToInt32(row.Cells["MaChucVu"].Value);
                var luong = chucVuBUS.LayLuongTheoChucVu(maChucVu);
                txtLuong.Text = luong.HasValue ? luong.Value.ToString() : "N/A";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
