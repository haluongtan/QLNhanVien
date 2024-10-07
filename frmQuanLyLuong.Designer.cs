namespace QLNhanVien
{
    partial class frmQuanLyLuong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnXoaLuong = new System.Windows.Forms.Button();
            this.btnSuaLuong = new System.Windows.Forms.Button();
            this.btnThemLuong = new System.Windows.Forms.Button();
            this.pnThongtin = new System.Windows.Forms.Panel();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblNam = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.lblPhuCap = new System.Windows.Forms.Label();
            this.lblLuong = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.txtPhuCap = new System.Windows.Forms.TextBox();
            this.txtLuongCoBan = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.grbQuanLyLuong = new System.Windows.Forms.GroupBox();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.pnThongtin.SuspendLayout();
            this.grbQuanLyLuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXoaLuong
            // 
            this.btnXoaLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaLuong.Location = new System.Drawing.Point(687, 185);
            this.btnXoaLuong.Name = "btnXoaLuong";
            this.btnXoaLuong.Size = new System.Drawing.Size(89, 63);
            this.btnXoaLuong.TabIndex = 10;
            this.btnXoaLuong.Text = "Xóa Lương";
            this.btnXoaLuong.UseVisualStyleBackColor = true;
            this.btnXoaLuong.Click += new System.EventHandler(this.btnXoaLuong_Click);
            // 
            // btnSuaLuong
            // 
            this.btnSuaLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaLuong.Location = new System.Drawing.Point(555, 185);
            this.btnSuaLuong.Name = "btnSuaLuong";
            this.btnSuaLuong.Size = new System.Drawing.Size(89, 63);
            this.btnSuaLuong.TabIndex = 9;
            this.btnSuaLuong.Text = "Sửa lương";
            this.btnSuaLuong.UseVisualStyleBackColor = true;
            this.btnSuaLuong.Click += new System.EventHandler(this.btnSuaLuong_Click);
            // 
            // btnThemLuong
            // 
            this.btnThemLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemLuong.Location = new System.Drawing.Point(429, 185);
            this.btnThemLuong.Name = "btnThemLuong";
            this.btnThemLuong.Size = new System.Drawing.Size(89, 63);
            this.btnThemLuong.TabIndex = 8;
            this.btnThemLuong.Text = "Thêm lương";
            this.btnThemLuong.UseVisualStyleBackColor = true;
            this.btnThemLuong.Click += new System.EventHandler(this.btnThemLuong_Click);
            // 
            // pnThongtin
            // 
            this.pnThongtin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnThongtin.Controls.Add(this.lblTenNV);
            this.pnThongtin.Controls.Add(this.lblNam);
            this.pnThongtin.Controls.Add(this.lblThang);
            this.pnThongtin.Controls.Add(this.lblPhuCap);
            this.pnThongtin.Controls.Add(this.lblLuong);
            this.pnThongtin.Controls.Add(this.txtTenNV);
            this.pnThongtin.Controls.Add(this.lblMaNV);
            this.pnThongtin.Controls.Add(this.txtNam);
            this.pnThongtin.Controls.Add(this.txtThang);
            this.pnThongtin.Controls.Add(this.txtPhuCap);
            this.pnThongtin.Controls.Add(this.txtLuongCoBan);
            this.pnThongtin.Controls.Add(this.txtMaNV);
            this.pnThongtin.Location = new System.Drawing.Point(29, 12);
            this.pnThongtin.Name = "pnThongtin";
            this.pnThongtin.Size = new System.Drawing.Size(363, 245);
            this.pnThongtin.TabIndex = 7;
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.Location = new System.Drawing.Point(44, 56);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(93, 15);
            this.lblTenNV.TabIndex = 11;
            this.lblTenNV.Text = "Tên Nhân Viên:";
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNam.Location = new System.Drawing.Point(44, 206);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(36, 15);
            this.lblNam.TabIndex = 11;
            this.lblNam.Text = "Năm:";
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThang.Location = new System.Drawing.Point(44, 165);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(46, 15);
            this.lblThang.TabIndex = 10;
            this.lblThang.Text = "Tháng:";
            // 
            // lblPhuCap
            // 
            this.lblPhuCap.AutoSize = true;
            this.lblPhuCap.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhuCap.Location = new System.Drawing.Point(44, 125);
            this.lblPhuCap.Name = "lblPhuCap";
            this.lblPhuCap.Size = new System.Drawing.Size(57, 15);
            this.lblPhuCap.TabIndex = 9;
            this.lblPhuCap.Text = "Phụ Cấp:";
            // 
            // lblLuong
            // 
            this.lblLuong.AutoSize = true;
            this.lblLuong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuong.Location = new System.Drawing.Point(44, 92);
            this.lblLuong.Name = "lblLuong";
            this.lblLuong.Size = new System.Drawing.Size(92, 15);
            this.lblLuong.TabIndex = 8;
            this.lblLuong.Text = "Lương Cơ Bản:";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(146, 56);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(100, 20);
            this.txtTenNV.TabIndex = 5;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Location = new System.Drawing.Point(44, 20);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(89, 15);
            this.lblMaNV.TabIndex = 7;
            this.lblMaNV.Text = "Mã Nhân Viên:";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(146, 206);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(100, 20);
            this.txtNam.TabIndex = 5;
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(146, 163);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(100, 20);
            this.txtThang.TabIndex = 4;
            // 
            // txtPhuCap
            // 
            this.txtPhuCap.Location = new System.Drawing.Point(146, 125);
            this.txtPhuCap.Name = "txtPhuCap";
            this.txtPhuCap.Size = new System.Drawing.Size(100, 20);
            this.txtPhuCap.TabIndex = 3;
            // 
            // txtLuongCoBan
            // 
            this.txtLuongCoBan.Location = new System.Drawing.Point(146, 90);
            this.txtLuongCoBan.Name = "txtLuongCoBan";
            this.txtLuongCoBan.Size = new System.Drawing.Size(100, 20);
            this.txtLuongCoBan.TabIndex = 2;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(146, 20);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(100, 20);
            this.txtMaNV.TabIndex = 1;
            // 
            // grbQuanLyLuong
            // 
            this.grbQuanLyLuong.Controls.Add(this.dgvLuong);
            this.grbQuanLyLuong.Location = new System.Drawing.Point(13, 263);
            this.grbQuanLyLuong.Name = "grbQuanLyLuong";
            this.grbQuanLyLuong.Size = new System.Drawing.Size(776, 397);
            this.grbQuanLyLuong.TabIndex = 6;
            this.grbQuanLyLuong.TabStop = false;
            this.grbQuanLyLuong.Text = "Thống kê lương";
            // 
            // dgvLuong
            // 
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLuong.Location = new System.Drawing.Point(3, 16);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.Size = new System.Drawing.Size(770, 378);
            this.dgvLuong.TabIndex = 0;
            this.dgvLuong.TabStop = false;
            this.dgvLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLuong_CellClick);
            this.dgvLuong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLuong_CellContentClick);
            // 
            // frmQuanLyLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 670);
            this.Controls.Add(this.btnXoaLuong);
            this.Controls.Add(this.btnSuaLuong);
            this.Controls.Add(this.btnThemLuong);
            this.Controls.Add(this.pnThongtin);
            this.Controls.Add(this.grbQuanLyLuong);
            this.Name = "frmQuanLyLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuanLyLuong";
            this.Load += new System.EventHandler(this.frmQuanLyLuong_Load);
            this.pnThongtin.ResumeLayout(false);
            this.pnThongtin.PerformLayout();
            this.grbQuanLyLuong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXoaLuong;
        private System.Windows.Forms.Button btnSuaLuong;
        private System.Windows.Forms.Button btnThemLuong;
        private System.Windows.Forms.Panel pnThongtin;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.Label lblPhuCap;
        private System.Windows.Forms.Label lblLuong;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.TextBox txtPhuCap;
        private System.Windows.Forms.TextBox txtLuongCoBan;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.GroupBox grbQuanLyLuong;
        private System.Windows.Forms.DataGridView dgvLuong;
    }
}