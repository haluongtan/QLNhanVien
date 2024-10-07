namespace QLNhanVien
{
    partial class frmThemHopDong
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
            this.components = new System.ComponentModel.Container();
            this.txtThoat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpNgayHH = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayDK = new System.Windows.Forms.DateTimePicker();
            this.txtLoaiHD = new System.Windows.Forms.TextBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblNgayHH = new System.Windows.Forms.Label();
            this.lblNgayDK = new System.Windows.Forms.Label();
            this.lblLoaiHD = new System.Windows.Forms.Label();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.grbHopDong = new System.Windows.Forms.GroupBox();
            this.dgvHopDong = new System.Windows.Forms.DataGridView();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.grbHopDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // txtThoat
            // 
            this.txtThoat.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThoat.Location = new System.Drawing.Point(184, 229);
            this.txtThoat.Name = "txtThoat";
            this.txtThoat.Size = new System.Drawing.Size(75, 36);
            this.txtThoat.TabIndex = 7;
            this.txtThoat.Text = "Thoát";
            this.txtThoat.UseVisualStyleBackColor = true;
            this.txtThoat.Click += new System.EventHandler(this.txtThoat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(57, 229);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 36);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtThoat);
            this.panel1.Controls.Add(this.dtpNgayHH);
            this.panel1.Controls.Add(this.dtpNgayDK);
            this.panel1.Controls.Add(this.txtLoaiHD);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.txtTenNV);
            this.panel1.Controls.Add(this.txtMaNV);
            this.panel1.Controls.Add(this.lblNgayHH);
            this.panel1.Controls.Add(this.lblNgayDK);
            this.panel1.Controls.Add(this.lblLoaiHD);
            this.panel1.Controls.Add(this.lblTenNV);
            this.panel1.Controls.Add(this.lblMaNV);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 279);
            this.panel1.TabIndex = 6;
            // 
            // dtpNgayHH
            // 
            this.dtpNgayHH.Location = new System.Drawing.Point(159, 189);
            this.dtpNgayHH.Name = "dtpNgayHH";
            this.dtpNgayHH.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayHH.TabIndex = 4;
            // 
            // dtpNgayDK
            // 
            this.dtpNgayDK.Location = new System.Drawing.Point(159, 148);
            this.dtpNgayDK.Name = "dtpNgayDK";
            this.dtpNgayDK.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayDK.TabIndex = 3;
            // 
            // txtLoaiHD
            // 
            this.txtLoaiHD.Location = new System.Drawing.Point(159, 108);
            this.txtLoaiHD.Name = "txtLoaiHD";
            this.txtLoaiHD.Size = new System.Drawing.Size(136, 20);
            this.txtLoaiHD.TabIndex = 2;
            this.txtLoaiHD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoaiHD_KeyPress);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Enabled = false;
            this.txtTenNV.Location = new System.Drawing.Point(159, 68);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(156, 20);
            this.txtTenNV.TabIndex = 1;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Location = new System.Drawing.Point(159, 27);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(100, 20);
            this.txtMaNV.TabIndex = 0;
            // 
            // lblNgayHH
            // 
            this.lblNgayHH.AutoSize = true;
            this.lblNgayHH.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayHH.Location = new System.Drawing.Point(46, 194);
            this.lblNgayHH.Name = "lblNgayHH";
            this.lblNgayHH.Size = new System.Drawing.Size(86, 15);
            this.lblNgayHH.TabIndex = 17;
            this.lblNgayHH.Text = "Ngày Hết Hạn:";
            // 
            // lblNgayDK
            // 
            this.lblNgayDK.AutoSize = true;
            this.lblNgayDK.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayDK.Location = new System.Drawing.Point(46, 153);
            this.lblNgayDK.Name = "lblNgayDK";
            this.lblNgayDK.Size = new System.Drawing.Size(87, 15);
            this.lblNgayDK.TabIndex = 16;
            this.lblNgayDK.Text = "Ngày Đăng Kí:";
            // 
            // lblLoaiHD
            // 
            this.lblLoaiHD.AutoSize = true;
            this.lblLoaiHD.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiHD.Location = new System.Drawing.Point(46, 113);
            this.lblLoaiHD.Name = "lblLoaiHD";
            this.lblLoaiHD.Size = new System.Drawing.Size(92, 15);
            this.lblLoaiHD.TabIndex = 15;
            this.lblLoaiHD.Text = "Loại Hợp Đồng:";
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.Location = new System.Drawing.Point(46, 73);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(93, 15);
            this.lblTenNV.TabIndex = 14;
            this.lblTenNV.Text = "Tên Nhân Viên:";
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Location = new System.Drawing.Point(46, 32);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(89, 15);
            this.lblMaNV.TabIndex = 13;
            this.lblMaNV.Text = "Mã Nhân Viên:";
            // 
            // grbHopDong
            // 
            this.grbHopDong.Controls.Add(this.dgvHopDong);
            this.grbHopDong.Location = new System.Drawing.Point(8, 297);
            this.grbHopDong.Name = "grbHopDong";
            this.grbHopDong.Size = new System.Drawing.Size(713, 227);
            this.grbHopDong.TabIndex = 5;
            this.grbHopDong.TabStop = false;
            this.grbHopDong.Text = "Hợp đồng";
            // 
            // dgvHopDong
            // 
            this.dgvHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHopDong.Location = new System.Drawing.Point(3, 16);
            this.dgvHopDong.Name = "dgvHopDong";
            this.dgvHopDong.Size = new System.Drawing.Size(707, 208);
            this.dgvHopDong.TabIndex = 0;
            this.dgvHopDong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHopDong_CellClick);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // frmThemHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 535);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grbHopDong);
            this.Name = "frmThemHopDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThemHopDong";
            this.Load += new System.EventHandler(this.frmThemHopDong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbHopDong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button txtThoat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grbHopDong;
        private System.Windows.Forms.DataGridView dgvHopDong;
        private System.Windows.Forms.DateTimePicker dtpNgayHH;
        private System.Windows.Forms.DateTimePicker dtpNgayDK;
        private System.Windows.Forms.TextBox txtLoaiHD;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblNgayHH;
        private System.Windows.Forms.Label lblNgayDK;
        private System.Windows.Forms.Label lblLoaiHD;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.ErrorProvider err;
    }
}