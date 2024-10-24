namespace QuanLyNhanSu
{
    partial class frmQuanLySuKien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLySuKien));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLoaiSuKien = new System.Windows.Forms.ComboBox();
            this.dtpNgayGioToChuc = new System.Windows.Forms.DateTimePicker();
            this.rtbNoiDung = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTieuDe = new System.Windows.Forms.TextBox();
            this.btnLuuSuKien = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.dgvSuKien = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuKien)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbLoaiSuKien);
            this.groupBox1.Controls.Add(this.dtpNgayGioToChuc);
            this.groupBox1.Controls.Add(this.rtbNoiDung);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTieuDe);
            this.groupBox1.Location = new System.Drawing.Point(12, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 336);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sự kiện";
            // 
            // cmbLoaiSuKien
            // 
            this.cmbLoaiSuKien.FormattingEnabled = true;
            this.cmbLoaiSuKien.Location = new System.Drawing.Point(107, 286);
            this.cmbLoaiSuKien.Name = "cmbLoaiSuKien";
            this.cmbLoaiSuKien.Size = new System.Drawing.Size(121, 21);
            this.cmbLoaiSuKien.TabIndex = 7;
            // 
            // dtpNgayGioToChuc
            // 
            this.dtpNgayGioToChuc.Location = new System.Drawing.Point(107, 221);
            this.dtpNgayGioToChuc.Name = "dtpNgayGioToChuc";
            this.dtpNgayGioToChuc.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayGioToChuc.TabIndex = 6;
            // 
            // rtbNoiDung
            // 
            this.rtbNoiDung.Location = new System.Drawing.Point(107, 104);
            this.rtbNoiDung.Name = "rtbNoiDung";
            this.rtbNoiDung.Size = new System.Drawing.Size(204, 96);
            this.rtbNoiDung.TabIndex = 5;
            this.rtbNoiDung.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Loại sự kiện";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngày giờ tổ chức";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nội dung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tiêu đề";
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Location = new System.Drawing.Point(107, 57);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(204, 20);
            this.txtTieuDe.TabIndex = 0;
            // 
            // btnLuuSuKien
            // 
            this.btnLuuSuKien.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuSuKien.Location = new System.Drawing.Point(12, 575);
            this.btnLuuSuKien.Name = "btnLuuSuKien";
            this.btnLuuSuKien.Size = new System.Drawing.Size(77, 40);
            this.btnLuuSuKien.TabIndex = 1;
            this.btnLuuSuKien.Text = "Lưu sự kiện";
            this.btnLuuSuKien.UseVisualStyleBackColor = true;
            this.btnLuuSuKien.Click += new System.EventHandler(this.btnLuuSuKien_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.Location = new System.Drawing.Point(133, 575);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(77, 40);
            this.btnEmail.TabIndex = 2;
            this.btnEmail.Text = "Gửi Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // dgvSuKien
            // 
            this.dgvSuKien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuKien.Location = new System.Drawing.Point(345, 218);
            this.dgvSuKien.Name = "dgvSuKien";
            this.dgvSuKien.Size = new System.Drawing.Size(522, 387);
            this.dgvSuKien.TabIndex = 3;
            this.dgvSuKien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuKien_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(315, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 36);
            this.label5.TabIndex = 1;
            this.label5.Text = "Quản Lý Sự Kiện";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(262, 575);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(77, 40);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(787, 651);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 41);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmQuanLySuKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 704);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvSuKien);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnLuuSuKien);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQuanLySuKien";
            this.Text = "Quản lý sự kiện";
            this.Load += new System.EventHandler(this.frmQuanLySuKien_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuKien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTieuDe;
        private System.Windows.Forms.ComboBox cmbLoaiSuKien;
        private System.Windows.Forms.DateTimePicker dtpNgayGioToChuc;
        private System.Windows.Forms.RichTextBox rtbNoiDung;
        private System.Windows.Forms.Button btnLuuSuKien;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.DataGridView dgvSuKien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
    }
}