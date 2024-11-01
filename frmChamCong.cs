using BUS;
using DAL.Entities;
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
    public partial class frmChamCong : Form
    {
        private ChamCongBUS chamCongBUS;

        public frmChamCong()
        {
            InitializeComponent();
            chamCongBUS = new ChamCongBUS();

        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadChamCongData();
        }
        public void AddNhanVienToChamCong(int maNhanVien, string tenNhanVien)
        {
            // Thêm nhân viên vào DataGridView với tình trạng mặc định "Đi Làm"
            dgvChamCong.Rows.Add(maNhanVien, tenNhanVien, "Đi Làm");
        }
        private void SetupDataGridView()
        {
            dgvChamCong.Columns.Clear();
            dgvChamCong.Columns.Add("MaNhanVien", "Mã Nhân Viên");
            dgvChamCong.Columns.Add("TenNhanVien", "Tên Nhân Viên");
            DataGridViewComboBoxColumn tinhTrangColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Tình Trạng",
                Name = "TinhTrang"
            };
            tinhTrangColumn.Items.AddRange("Đi Làm", "Nghỉ Phép", "Đi Trễ", "Không Đi Làm");
            dgvChamCong.Columns.Add(tinhTrangColumn);
            dgvChamCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LoadChamCongData()
        {
            DateTime selectedDate = dtpNgay.Value.Date;
            var chamCongList = chamCongBUS.LayDanhSachChamCongTheoNgay(selectedDate);
            dgvChamCong.Rows.Clear();

            if (chamCongList.Count > 0)
            {
                foreach (var chamCong in chamCongList)
                {
                    dgvChamCong.Rows.Add(chamCong.MaNhanVien, chamCong.TenNhanVien, chamCong.TrangThai);
                }
            }
            else
            {
                var nhanVienList = chamCongBUS.LayDanhSachNhanVien();
                foreach (var nv in nhanVienList)
                {
                    dgvChamCong.Rows.Add(nv.MaNhanVien, nv.HoTen, "Đi Làm");
                }
            }
        }
        public void ApplyRoleRestrictions(string role)
        {
            if (role == "nhanvien")
            {
                // Vô hiệu hóa các nút lưu và xóa để nhân viên không thể chỉnh sửa
                btnLuu.Enabled = false;
                dgvChamCong.ReadOnly = true;
                btnTinhLuongThang.Visible = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvChamCong.Rows)
            {
                if (row.Cells["MaNhanVien"].Value != null)
                {
                    int maNhanVien = Convert.ToInt32(row.Cells["MaNhanVien"].Value);
                    string tinhTrang = row.Cells["TinhTrang"].Value.ToString();
                    DateTime selectedDate = dtpNgay.Value.Date;

                    ChamCong chamCong = new ChamCong
                    {
                        MaNhanVien = maNhanVien,
                        TenNhanVien = row.Cells["TenNhanVien"].Value.ToString(),
                        Ngay = selectedDate,
                        TrangThai = tinhTrang
                    };

                    chamCongBUS.LuuChamCong(chamCong);
                }
            }

            MessageBox.Show("Chấm công đã được lưu thành công!");
        }

     
        
        private void LoadChamCongDataForDate(DateTime selectedDate)
        {
            using (var dbContext = new Model1())
            {
                // Lấy danh sách chấm công cho ngày đã chọn
                var chamCongList = dbContext.ChamCong
                                            .Where(cc => DbFunctions.TruncateTime(cc.Ngay) == selectedDate.Date)
                                            .Select(cc => new
                                            {
                                                cc.MaNhanVien,
                                                cc.TenNhanVien,
                                                cc.TrangThai
                                            }).ToList();
                dgvChamCong.Rows.Clear(); // Xóa dữ liệu cũ trước khi hiển thị mới

                if (chamCongList.Count > 0)
                {
                    // Nếu có bản ghi chấm công cho ngày đó, hiển thị chúng
                    foreach (var chamCong in chamCongList)
                    {
                        dgvChamCong.Rows.Add(chamCong.MaNhanVien, chamCong.TenNhanVien, chamCong.TrangThai);
                    }
                }
                else
                {
                    // Nếu không có bản ghi nào, hiển thị danh sách nhân viên mặc định
                    var nhanVienList = dbContext.NhanVien.Select(nv => new
                    {
                        nv.MaNhanVien,
                        nv.HoTen,
                        TinhTrang = "Đi Làm" // Giá trị mặc định cho tình trạng là "Đi Làm"
                    }).ToList();

                    foreach (var nv in nhanVienList)
                    {
                        dgvChamCong.Rows.Add(nv.MaNhanVien, nv.HoTen, nv.TinhTrang);
                    }
                }
            }
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadChamCongDataForDate(dtpNgay.Value);

        }

        

        private void dgvChamCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTinhLuongThang_Click(object sender, EventArgs e)
        {
            frmTongLuong frm = new frmTongLuong();
            frm.MdiParent = this.MdiParent; // Nếu đang dùng MDI
            frm.Show();

            // Sau khi mở form frmTongLuong, bạn có thể tính lương và hiển thị
            frm.TinhLuongThang();
        }

  
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
