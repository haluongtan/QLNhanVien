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
    public partial class frmSuaLuong : Form
    {
        private LuongBUS luongBUS;
        private int maNhanVien;
        private frmQuanLyLuong parentForm;

        public frmSuaLuong(frmQuanLyLuong parent, int maNV, string tenNV, decimal luongCB, decimal phuCap, int thang, int nam)
        {
            InitializeComponent();
            luongBUS = new LuongBUS();
            maNhanVien = maNV;
            parentForm = parent;

            txtMaNV.Text = maNV.ToString();
            txtTenNV.Text = tenNV;
            txtLuongCoBan.Text = luongCB.ToString();
            txtPhuCap.Text = phuCap.ToString();
            txtThang.Text = thang.ToString();
            txtNam.Text = nam.ToString();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                Luong luong = luongBUS.LayLuongTheoMaNhanVien(maNhanVien);
                if (luong != null)
                {
                    luong.LuongCoBan = decimal.Parse(txtLuongCoBan.Text);
                    luong.PhuCap = decimal.Parse(txtPhuCap.Text);
                    luong.Thang = int.Parse(txtThang.Text);
                    luong.Nam = int.Parse(txtNam.Text);

                    luongBUS.SuaLuong(luong);
                    MessageBox.Show("Cập nhật lương thành công!");
                    parentForm.LoadLuongData();
                    this.Close();
                }
            }
        }
        private bool ValidateInputs()
        {
            
            err.Clear();
            bool isValid = true;

            if (string.IsNullOrEmpty(txtLuongCoBan.Text) || !decimal.TryParse(txtLuongCoBan.Text, out _))
            {
                err.SetError(txtLuongCoBan, "Lương cơ bản phải là số.");
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtPhuCap.Text) || !decimal.TryParse(txtPhuCap.Text, out _))
            {
                err.SetError(txtPhuCap, "Phụ cấp phải là số.");
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtThang.Text) || !int.TryParse(txtThang.Text, out _))
            {
                err.SetError(txtThang, "Tháng phải là số.");
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtNam.Text) || !int.TryParse(txtNam.Text, out _))
            {
                err.SetError(txtNam, "Năm phải là số.");
                isValid = false;
            }

            return isValid;
        }

        private void frmSuaLuong_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
