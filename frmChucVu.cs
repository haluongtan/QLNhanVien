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
        private Model1 dbContext;
        private Dictionary<int, int> luongTheoChucVu = new Dictionary<int, int>
        {
            { 1, 10000 },  // Nhân viên
            { 2, 15000 },  // Trưởng phòng
            { 3, 12000 }   // Quản lý dự án
        };


        public frmChucVu()
        {
            InitializeComponent();
            dbContext = new Model1();  // Khởi tạo DbContext

        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            
            var chucVus = new Dictionary<int, string>
            {
                { 1, "Nhân Viên" },
                { 2, "Trưởng Phòng" },
                { 3, "Quản Lý Dự Án" }
            };

            cmbChucVu.DataSource = new BindingSource(chucVus, null);
            cmbChucVu.DisplayMember = "Value";
            cmbChucVu.ValueMember = "Key";

            cmbChucVu.SelectedIndexChanged += cmbChucVu_SelectedIndexChanged;
        }
    
        private void cmbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChucVu.SelectedValue != null && cmbChucVu.SelectedValue is int)
            {
                int selectedChucVuId = (int)cmbChucVu.SelectedValue;

                // Lọc danh sách nhân viên theo mã chức vụ
                var nhanVienList = dbContext.NhanVien
                    .Where(nv => nv.MaChucVu == selectedChucVuId)
                    .ToList();

                // Hiển thị danh sách nhân viên trong DataGridView
                dgvNhanVien.DataSource = nhanVienList;

                // Hiển thị lương tương ứng với mã chức vụ
                if (luongTheoChucVu.ContainsKey(selectedChucVuId))
                {
                    txtLuong.Text = luongTheoChucVu[selectedChucVuId].ToString();
                }

                if (nhanVienList.Count == 0)
                {
                    MessageBox.Show("Không có nhân viên nào trong chức vụ này.");
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
                txtChucVu.Text = row.Cells["MaChucVu"].Value.ToString();

                // Hiển thị lương tương ứng với mã chức vụ của nhân viên
                int maChucVu = Convert.ToInt32(row.Cells["MaChucVu"].Value);
                if (luongTheoChucVu.ContainsKey(maChucVu))
                {
                    txtLuong.Text = luongTheoChucVu[maChucVu].ToString();
                }
                else
                {
                    txtLuong.Text = "N/A"; // Nếu không có lương tương ứng
                }
            }
            }
    }
}
