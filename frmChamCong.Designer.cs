namespace QLNhanVien
{
    partial class frmChamCong
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvChamCong = new System.Windows.Forms.DataGridView();
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXoaChamCong = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnTinhLuongThang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(303, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chấm Công ";
            // 
            // dgvChamCong
            // 
            this.dgvChamCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamCong.Location = new System.Drawing.Point(12, 129);
            this.dgvChamCong.Name = "dgvChamCong";
            this.dgvChamCong.Size = new System.Drawing.Size(821, 383);
            this.dgvChamCong.TabIndex = 7;
            this.dgvChamCong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChamCong_CellContentClick);
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay.Location = new System.Drawing.Point(12, 555);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(71, 15);
            this.lblNgay.TabIndex = 1;
            this.lblNgay.Text = "Chọn Ngày:";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgay.Location = new System.Drawing.Point(101, 550);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(200, 20);
            this.dtpNgay.TabIndex = 8;
            this.dtpNgay.ValueChanged += new System.EventHandler(this.dtpNgay_ValueChanged);
            // 
            // btnXoaChamCong
            // 
            this.btnXoaChamCong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaChamCong.Location = new System.Drawing.Point(503, 532);
            this.btnXoaChamCong.Name = "btnXoaChamCong";
            this.btnXoaChamCong.Size = new System.Drawing.Size(99, 70);
            this.btnXoaChamCong.TabIndex = 9;
            this.btnXoaChamCong.Text = "Xóa Chấm Công";
            this.btnXoaChamCong.UseVisualStyleBackColor = true;
            this.btnXoaChamCong.Click += new System.EventHandler(this.btnXoaChamCong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(352, 532);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(99, 70);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnTinhLuongThang
            // 
            this.btnTinhLuongThang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhLuongThang.Location = new System.Drawing.Point(654, 532);
            this.btnTinhLuongThang.Name = "btnTinhLuongThang";
            this.btnTinhLuongThang.Size = new System.Drawing.Size(99, 70);
            this.btnTinhLuongThang.TabIndex = 11;
            this.btnTinhLuongThang.Text = "Tính Lương Tháng";
            this.btnTinhLuongThang.UseVisualStyleBackColor = true;
            this.btnTinhLuongThang.Click += new System.EventHandler(this.btnTinhLuongThang_Click);
            // 
            // frmChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 615);
            this.Controls.Add(this.btnTinhLuongThang);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoaChamCong);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.dgvChamCong);
            this.Controls.Add(this.lblNgay);
            this.Controls.Add(this.label1);
            this.Name = "frmChamCong";
            this.Text = "frmChamCong";
            this.Load += new System.EventHandler(this.frmChamCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvChamCong;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Button btnXoaChamCong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnTinhLuongThang;
    }
}