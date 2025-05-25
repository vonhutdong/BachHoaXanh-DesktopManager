namespace SieuThiBHX
{
    partial class frmCaLam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaLam));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLamMoi = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGioKetThuc = new System.Windows.Forms.MaskedTextBox();
            this.txtTenCaLam = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGioBatDau = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvCaLam = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.toolStrip1.SuspendLayout();
            this.guna2GroupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLam)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlToolTip1
            // 
            this.guna2HtmlToolTip1.AllowLinksHandling = true;
            this.guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(59, 24);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(70, 24);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(58, 24);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnXoa,
            this.btnSua,
            this.btnLamMoi,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(945, 27);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.Image")));
            this.btnLamMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(91, 24);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(71, 24);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2GroupBox3.Controls.Add(this.tableLayoutPanel1);
            this.guna2GroupBox3.CustomBorderColor = System.Drawing.Color.DarkSeaGreen;
            this.guna2GroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GroupBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox3.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox3.Location = new System.Drawing.Point(0, 27);
            this.guna2GroupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.Size = new System.Drawing.Size(945, 176);
            this.guna2GroupBox3.TabIndex = 14;
            this.guna2GroupBox3.Text = "Quản lí ca làm";
            this.guna2GroupBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtGioKetThuc, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTenCaLam, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtGioBatDau, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(945, 136);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 52);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tên ca làm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGioKetThuc
            // 
            this.txtGioKetThuc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGioKetThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGioKetThuc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtGioKetThuc.Location = new System.Drawing.Point(474, 106);
            this.txtGioKetThuc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGioKetThuc.Mask = "90:00";
            this.txtGioKetThuc.Name = "txtGioKetThuc";
            this.txtGioKetThuc.Size = new System.Drawing.Size(469, 29);
            this.txtGioKetThuc.TabIndex = 21;
            this.txtGioKetThuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGioKetThuc.ValidatingType = typeof(System.DateTime);
            // 
            // txtTenCaLam
            // 
            this.txtTenCaLam.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTenCaLam.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtTenCaLam.BorderRadius = 2;
            this.txtTenCaLam.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenCaLam.DefaultText = "";
            this.txtTenCaLam.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenCaLam.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenCaLam.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenCaLam.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenCaLam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenCaLam.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenCaLam.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTenCaLam.ForeColor = System.Drawing.Color.Black;
            this.txtTenCaLam.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenCaLam.Location = new System.Drawing.Point(475, 3);
            this.txtTenCaLam.Name = "txtTenCaLam";
            this.txtTenCaLam.PlaceholderText = "";
            this.txtTenCaLam.SelectedText = "";
            this.txtTenCaLam.Size = new System.Drawing.Size(467, 46);
            this.txtTenCaLam.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtTenCaLam.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(2, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(468, 32);
            this.label3.TabIndex = 19;
            this.label3.Text = "Giờ kết thúc";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGioBatDau
            // 
            this.txtGioBatDau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGioBatDau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGioBatDau.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtGioBatDau.Location = new System.Drawing.Point(474, 54);
            this.txtGioBatDau.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGioBatDau.Mask = "90:00";
            this.txtGioBatDau.Name = "txtGioBatDau";
            this.txtGioBatDau.Size = new System.Drawing.Size(469, 29);
            this.txtGioBatDau.TabIndex = 20;
            this.txtGioBatDau.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGioBatDau.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(468, 52);
            this.label2.TabIndex = 18;
            this.label2.Text = "Giờ bắt đầu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2GroupBox1.Controls.Add(this.dgvCaLam);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.DarkSeaGreen;
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 203);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(945, 270);
            this.guna2GroupBox1.TabIndex = 15;
            this.guna2GroupBox1.Text = "Danh sách ca làm";
            this.guna2GroupBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvCaLam
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCaLam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaLam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCaLam.ColumnHeadersHeight = 4;
            this.dgvCaLam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCaLam.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCaLam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCaLam.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCaLam.Location = new System.Drawing.Point(0, 40);
            this.dgvCaLam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvCaLam.Name = "dgvCaLam";
            this.dgvCaLam.RowHeadersVisible = false;
            this.dgvCaLam.RowHeadersWidth = 51;
            this.dgvCaLam.RowTemplate.Height = 24;
            this.dgvCaLam.Size = new System.Drawing.Size(945, 230);
            this.dgvCaLam.TabIndex = 1;
            this.dgvCaLam.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCaLam.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCaLam.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCaLam.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCaLam.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCaLam.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCaLam.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCaLam.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCaLam.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCaLam.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.dgvCaLam.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCaLam.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCaLam.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvCaLam.ThemeStyle.ReadOnly = false;
            this.dgvCaLam.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCaLam.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCaLam.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.dgvCaLam.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCaLam.ThemeStyle.RowsStyle.Height = 24;
            this.dgvCaLam.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCaLam.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCaLam.Click += new System.EventHandler(this.dgvCaLam_Click);
            // 
            // frmCaLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 473);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.guna2GroupBox3);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmCaLam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCaLam";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCaLam_FormClosing);
            this.Load += new System.EventHandler(this.frmCaLam_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.guna2GroupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlToolTip guna2HtmlToolTip1;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLamMoi;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private Guna.UI2.WinForms.Guna2TextBox txtTenCaLam;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtGioBatDau;
        private System.Windows.Forms.MaskedTextBox txtGioKetThuc;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCaLam;
    }
}