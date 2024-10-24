using BUS;
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
    public partial class frmPhongBan : Form
    {
        private PhongBanBUS phongBanBUS = new PhongBanBUS();
        private NhanVienBUS nhanVienBUS = new NhanVienBUS(); public frmPhongBan()
        {
            InitializeComponent();

        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
           LoadData();

            dgvNhanVien.CellClick += dgvNhanVien_CellClick;

        }
        private void LoadData()
        {

            var phongBans = phongBanBUS.LayDanhSachPhongBan();
            cmbPhongBan.DataSource = phongBans;
            cmbPhongBan.DisplayMember = "TenPhongBan";
            cmbPhongBan.ValueMember = "MaPhongBan";
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


        private void cmbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPhongBan.SelectedValue != null && cmbPhongBan.SelectedValue is int)
            {
                int selectedPhongBanId = (int)cmbPhongBan.SelectedValue;

                // Lọc danh sách nhân viên theo mã phòng ban qua BUS
                var nhanVienList = phongBanBUS.LayDanhSachNhanVienTheoPhongBan(selectedPhongBanId);

                // Hiển thị danh sách nhân viên trong DataGridView
                dgvNhanVien.DataSource = nhanVienList;

                if (nhanVienList.Count == 0)
                {
                    MessageBox.Show("Không có nhân viên nào trong phòng ban này.");
                }

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

                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

                if (row.Cells["GioiTinh"].Value.ToString() == "Nam")
                {
                    rbNam.Checked = true;
                }
                else
                {
                    rbNu.Checked = true;
                }

                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
