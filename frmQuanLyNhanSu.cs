using QLNhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class frmQuanLyNhanSu : Form
    {
        public frmQuanLyNhanSu()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm)
        {
            // Đặt form con là MDI child
            childForm.MdiParent = this;

            // Thiết lập để form con lấp đầy form cha
            childForm.Dock = DockStyle.Fill;

            // Hiển thị form con
            childForm.Show();
        }

        private void frmQuanLyNhanSu_Load(object sender, EventArgs e)
        {

        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain Main = new frmMain();
            OpenChildForm(Main);
        }

        private void quảnLýPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhongBan phongBan = new frmPhongBan();
            OpenChildForm(phongBan);
        }

        private void quảnLýChứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChucVu chucVu = new frmChucVu();
            OpenChildForm(chucVu);
        }

        private void quảnLýHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHopDong hopDong = new frmHopDong();
            OpenChildForm(hopDong);

        }

        private void sựKiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLySuKien frmQuanLySuKien = new frmQuanLySuKien();
            OpenChildForm(frmQuanLySuKien);
        }

        private void quảnLýLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyLuong quanLyLuong = new frmQuanLyLuong();
            OpenChildForm(quanLyLuong);
        }

        private void quảnLýChấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChamCong chamCong = new frmChamCong();
            OpenChildForm(chamCong);
        }

        private void quảnLýỨngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUngLuong frmUngLuong = new frmUngLuong();
            OpenChildForm(frmUngLuong);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyTk frmQuanLyTk = new frmQuanLyTk();
            OpenChildForm(frmQuanLyTk);
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            OpenChildForm(frmLogin);
        }
    }
}
