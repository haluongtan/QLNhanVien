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
        private NhanVien NhanVien;

        public frmChamCong()
        {
            InitializeComponent();
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
 
        }
        public void AddNhanVienToChamCong(int maNhanVien, string tenNhanVien)
        {
            // Thêm nhân viên vào DataGridView với tình trạng mặc định "Đi Làm"
            dgvChamCong.Rows.Add(maNhanVien, tenNhanVien, "Đi Làm");
        }
        private void SetupDataGridView()
        {
            // Tạo các cột cho DataGridView
            DataGridViewTextBoxColumn maNhanVienColumn = new DataGridViewTextBoxColumn();
            maNhanVienColumn.HeaderText = "Mã Nhân Viên";
            maNhanVienColumn.Name = "MaNhanVien"; // Tên để truy xuất dữ liệu

            DataGridViewTextBoxColumn tenNhanVienColumn = new DataGridViewTextBoxColumn();
            tenNhanVienColumn.HeaderText = "Tên Nhân Viên";
            tenNhanVienColumn.Name = "TenNhanVien";

            DataGridViewComboBoxColumn tinhTrangColumn = new DataGridViewComboBoxColumn();
            tinhTrangColumn.HeaderText = "Tình Trạng";
            tinhTrangColumn.Name = "TinhTrang";
            tinhTrangColumn.Items.AddRange("Đi Làm", "Nghỉ Phép", "Đi Trễ", "Không Đi Làm");

            dgvChamCong.Columns.Add(maNhanVienColumn);
            dgvChamCong.Columns.Add(tenNhanVienColumn);
            dgvChamCong.Columns.Add(tinhTrangColumn);

            // Đặt AutoSize cho DataGridView để phù hợp với nội dung
            dgvChamCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LoadChamCongData()
        {
            using (var dbContext = new Model1())
            {
                // Lấy danh sách nhân viên chưa có chấm công
                var nhanVienList = dbContext.NhanVien.Select(nv => new
                {
                    nv.MaNhanVien,
                    nv.HoTen,
                    TinhTrang = "Đi Làm" // Giá trị mặc định cho Tình Trạng
                }).ToList();

                // Gán danh sách nhân viên vào DataGridView
                dgvChamCong.Rows.Clear(); // Xóa tất cả hàng trước khi thêm mới
                foreach (var nv in nhanVienList)
                {
                    dgvChamCong.Rows.Add(nv.MaNhanVien, nv.HoTen, nv.TinhTrang);
                }
            }
        }
        public void ApplyRoleRestrictions(string role)
        {
            if (role == "nhanvien")
            {
                // Vô hiệu hóa các nút lưu và xóa để nhân viên không thể chỉnh sửa
                btnLuu.Enabled = false;
                btnXoaChamCong.Enabled = false;
                dgvChamCong.ReadOnly = true;
                btnTinhLuongThang.Visible = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (var dbContext = new Model1())
            {
                // Lấy ngày đã chọn từ DateTimePicker
                DateTime selectedDate = dtpNgay.Value.Date;

                // Duyệt qua từng hàng trong DataGridView để lưu chấm công
                foreach (DataGridViewRow row in dgvChamCong.Rows)
                {
                    if (row.Cells["MaNhanVien"].Value != null)
                    {
                        int maNhanVien = Convert.ToInt32(row.Cells["MaNhanVien"].Value);
                        string tenNhanVien = row.Cells["TenNhanVien"].Value.ToString();
                        string tinhTrang = row.Cells["TinhTrang"].Value.ToString();

                        // Kiểm tra xem đã có bản ghi chấm công cho nhân viên này trong ngày đã chọn chưa
                        var existingRecord = dbContext.ChamCong
                            .FirstOrDefault(cc => cc.MaNhanVien == maNhanVien && DbFunctions.TruncateTime(cc.Ngay) == selectedDate);

                        if (existingRecord != null)
                        {
                            // Nếu đã có, cập nhật thông tin
                            existingRecord.TrangThai = tinhTrang;
                        }
                        else
                        {
                            // Nếu chưa có, thêm mới bản ghi
                            ChamCong chamCong = new ChamCong()
                            {
                                MaNhanVien = maNhanVien,
                                TenNhanVien = tenNhanVien,  // Lưu tên nhân viên
                                Ngay = selectedDate,
                                TrangThai = tinhTrang
                            };
                            dbContext.ChamCong.Add(chamCong);
                        }
                    }
                }
                dbContext.SaveChanges();
                MessageBox.Show("Chấm công đã được lưu thành công!");
            }
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

        private void btnXoaChamCong_Click(object sender, EventArgs e)
        {
            using (var dbContext = new Model1())
            {
                // Kiểm tra xem người dùng đã chọn hàng nào trong DataGridView chưa
                if (dgvChamCong.CurrentRow != null && dgvChamCong.CurrentRow.Cells["MaNhanVien"].Value != null)
                {
                    // Lấy mã nhân viên từ DataGridView
                    int maNhanVien = Convert.ToInt32(dgvChamCong.CurrentRow.Cells["MaNhanVien"].Value);

                    // Tìm kiếm bản ghi chấm công của nhân viên trong cơ sở dữ liệu
                    var chamCongToDelete = dbContext.ChamCong
                        .Where(cc => cc.MaNhanVien == maNhanVien)
                        .ToList();

                    if (chamCongToDelete.Count > 0)
                    {
                        // Nếu có bản ghi chấm công của nhân viên này, tiến hành xóa
                        dbContext.ChamCong.RemoveRange(chamCongToDelete);
                        dbContext.SaveChanges();

                        MessageBox.Show("Đã xóa chấm công của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Làm mới lại DataGridView sau khi xóa
                        LoadChamCongDataForDate(dtpNgay.Value); // Tải lại dữ liệu chấm công cho ngày hiện tại
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên không có chấm công để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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
    }
}
