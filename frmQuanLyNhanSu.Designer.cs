namespace QLNhanVien
{
    partial class frmQuanLyNhanSu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.danhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPhongBan = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hợpĐồngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripQuanLyLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripQuanLyChamCong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhToolStripMenuItem,
            this.quảnLýToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // danhToolStripMenuItem
            // 
            this.danhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripPhongBan,
            this.chứcVụToolStripMenuItem,
            this.hợpĐồngToolStripMenuItem,
            this.mainToolStripMenuItem});
            this.danhToolStripMenuItem.Name = "danhToolStripMenuItem";
            this.danhToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.danhToolStripMenuItem.Text = "Danh Mục";
            // 
            // toolStripPhongBan
            // 
            this.toolStripPhongBan.Name = "toolStripPhongBan";
            this.toolStripPhongBan.Size = new System.Drawing.Size(132, 22);
            this.toolStripPhongBan.Text = "Phòng Ban";
            this.toolStripPhongBan.Click += new System.EventHandler(this.toolStripPhongBan_Click);
            // 
            // chứcVụToolStripMenuItem
            // 
            this.chứcVụToolStripMenuItem.Name = "chứcVụToolStripMenuItem";
            this.chứcVụToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.chứcVụToolStripMenuItem.Text = "Chức Vụ";
            this.chứcVụToolStripMenuItem.Click += new System.EventHandler(this.chứcVụToolStripMenuItem_Click);
            // 
            // hợpĐồngToolStripMenuItem
            // 
            this.hợpĐồngToolStripMenuItem.Name = "hợpĐồngToolStripMenuItem";
            this.hợpĐồngToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.hợpĐồngToolStripMenuItem.Text = "Hợp Đồng";
            this.hợpĐồngToolStripMenuItem.Click += new System.EventHandler(this.hợpĐồngToolStripMenuItem_Click);
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.mainToolStripMenuItem.Text = "Main";
            this.mainToolStripMenuItem.Click += new System.EventHandler(this.mainToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripQuanLyLuong,
            this.toolStripQuanLyChamCong});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // toolStripQuanLyLuong
            // 
            this.toolStripQuanLyLuong.Name = "toolStripQuanLyLuong";
            this.toolStripQuanLyLuong.Size = new System.Drawing.Size(178, 22);
            this.toolStripQuanLyLuong.Text = "Quản lý lương";
            this.toolStripQuanLyLuong.Click += new System.EventHandler(this.toolStripQuanLyLuong_Click);
            // 
            // toolStripQuanLyChamCong
            // 
            this.toolStripQuanLyChamCong.Name = "toolStripQuanLyChamCong";
            this.toolStripQuanLyChamCong.Size = new System.Drawing.Size(178, 22);
            this.toolStripQuanLyChamCong.Text = "Quản lý chấm công";
            this.toolStripQuanLyChamCong.Click += new System.EventHandler(this.toolStripQuanLyChamCong_Click);
            // 
            // frmQuanLyNhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 742);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmQuanLyNhanSu";
            this.Text = "Quản lý nhân sự";
            this.Load += new System.EventHandler(this.frmQuanLyNhanSu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem danhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripPhongBan;
        private System.Windows.Forms.ToolStripMenuItem chứcVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hợpĐồngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripQuanLyLuong;
        private System.Windows.Forms.ToolStripMenuItem toolStripQuanLyChamCong;
    }
}