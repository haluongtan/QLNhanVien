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
    public partial class frmThemHopDong : Form
    {
        public frmThemHopDong()
        {
            InitializeComponent();
            err = new ErrorProvider();

        }

        private void frmThemHopDong_Load(object sender, EventArgs e)
        {
            using (var dbContext = new Model1())
            {
                // Query to get employees who don't have a contract yet
                var nhanVienWithoutContracts = (from nv in dbContext.NhanVien
                                                where !(from hd in dbContext.HopDong
                                                        select hd.MaNhanVien)
                                                        .Contains(nv.MaNhanVien)
                                                select new
                                                {
                                                    nv.MaNhanVien,
                                                    nv.HoTen
                                                }).ToList();

                // Bind data to DataGridView
                dgvHopDong.DataSource = nhanVienWithoutContracts;
                dgvHopDong.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                dgvHopDong.Columns["HoTen"].HeaderText = "Tên Nhân Viên";

                dgvHopDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHopDong.Rows[e.RowIndex];

                // Assign employee's information to the textboxes
                txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtTenNV.Text = row.Cells["HoTen"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            err.Clear();
            if (!string.IsNullOrEmpty(txtMaNV.Text))
            {
                if (!ValidateInputs()) return;
                using (var dbContext = new Model1())
                {
                    HopDong newContract = new HopDong()
                    {
                        MaNhanVien = Convert.ToInt32(txtMaNV.Text),
                        LoaiHopDong = txtLoaiHD.Text,
                        NgayKy = dtpNgayDK.Value,
                        NgayHetHan = dtpNgayHH.Value
                    };

                    dbContext.HopDong.Add(newContract);
                    dbContext.SaveChanges();

                    MessageBox.Show("Hợp đồng đã được thêm thành công!");
                    frmHopDong parentForm = (frmHopDong)Application.OpenForms["frmHopDong"];
                    if (parentForm != null)
                    {
                        parentForm.RefreshGrid(); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên.");
            }

        }
        private bool ValidateInputs()
        {
            bool isValid = true;
            err.Clear(); 

            if (string.IsNullOrEmpty(txtLoaiHD.Text))
            {
                err.SetError(txtLoaiHD, "Vui lòng nhập loại hợp đồng.");
                isValid = false;
            }
            return isValid;
        }


        private void txtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLoaiHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;  
                err.SetError(txtLoaiHD, "Chỉ được nhập ký tự chữ.");
            }
            else
            {
                err.SetError(txtLoaiHD, "");  
            }
        }
    }
}
