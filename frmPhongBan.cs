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
        private Model1 dbContext;
        public frmPhongBan()
        {
            InitializeComponent();
            dbContext = new Model1();  // Khởi tạo dbContext để kết nối với CSDL

        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            var phongBans = new Dictionary<int, string>
    {
        { 1, "IT" },
        { 2, "Marketing" },
        { 3, "Kế Toán" }
    };

            cmbPhongBan.DataSource = new BindingSource(phongBans, null);
            cmbPhongBan.DisplayMember = "Value";
            cmbPhongBan.ValueMember = "Key";

            dgvNhanVien.CellClick += dgvNhanVien_CellClick;


        }
   

        private void cmbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPhongBan.SelectedValue != null && cmbPhongBan.SelectedValue is int)
            {
                int selectedPhongBanId = (int)cmbPhongBan.SelectedValue;

                // Lọc danh sách nhân viên theo mã phòng ban
                var nhanVienList = dbContext.NhanVien
                    .Where(nv => nv.MaPhongBan == selectedPhongBanId)
                    .ToList();

                // Hiển thị danh sách nhân viên trong DataGridView
                dgvNhanVien.DataSource = nhanVienList;

                if (nhanVienList.Count == 0)
                {
                    MessageBox.Show("Không có nhân viên nào trong phòng ban này.");
                }
                dgvNhanVien.Columns["Luong"].Visible = false;
                dgvNhanVien.Columns["ChucVu"].Visible = false;
                dgvNhanVien.Columns["PhongBan"].Visible = false;
            }

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                // Hiển thị thông tin nhân viên lên các điều khiển tương ứng
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
    }
}
