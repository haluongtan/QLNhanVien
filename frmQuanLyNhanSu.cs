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
        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain Main = new frmMain();
            OpenChildForm(Main);
        }

        private void toolStripPhongBan_Click(object sender, EventArgs e)
        {
            frmPhongBan phongBan = new frmPhongBan();
            OpenChildForm(phongBan);
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChucVu chucVu = new frmChucVu();
            OpenChildForm(chucVu);
        }

        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHopDong hopDong = new frmHopDong();
            OpenChildForm(hopDong);
        }

        private void toolStripQuanLyLuong_Click(object sender, EventArgs e)
        {
            frmQuanLyLuong quanLyLuong = new frmQuanLyLuong();
            OpenChildForm(quanLyLuong);
        }

        private void toolStripQuanLyChamCong_Click(object sender, EventArgs e)
        {
            frmChamCong chamCong = new frmChamCong();
            OpenChildForm(chamCong);
        }

        private void frmQuanLyNhanSu_Load(object sender, EventArgs e)
        {

        }
    }
}
