namespace SieuThiBHX.Trong
{
    partial class frm_ThongKeTheoMaPhieuNhap
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMaPhieuNhap = new System.Windows.Forms.ComboBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rpt_ThongKeTheoMaPhieuNhap = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.InThongKeTheoMaPhieuNhap1 = new SieuThiBHX.Trong.InThongKeTheoMaPhieuNhap();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboMaPhieuNhap, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTim, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1255, 46);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboMaPhieuNhap
            // 
            this.cboMaPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMaPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaPhieuNhap.FormattingEnabled = true;
            this.cboMaPhieuNhap.Location = new System.Drawing.Point(255, 4);
            this.cboMaPhieuNhap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboMaPhieuNhap.Name = "cboMaPhieuNhap";
            this.cboMaPhieuNhap.Size = new System.Drawing.Size(243, 37);
            this.cboMaPhieuNhap.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(506, 4);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(141, 38);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.rpt_ThongKeTheoMaPhieuNhap, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 46);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1255, 616);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // rpt_ThongKeTheoMaPhieuNhap
            // 
            this.rpt_ThongKeTheoMaPhieuNhap.ActiveViewIndex = 0;
            this.rpt_ThongKeTheoMaPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpt_ThongKeTheoMaPhieuNhap.Cursor = System.Windows.Forms.Cursors.Default;
            this.rpt_ThongKeTheoMaPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpt_ThongKeTheoMaPhieuNhap.Location = new System.Drawing.Point(4, 4);
            this.rpt_ThongKeTheoMaPhieuNhap.Margin = new System.Windows.Forms.Padding(4);
            this.rpt_ThongKeTheoMaPhieuNhap.Name = "rpt_ThongKeTheoMaPhieuNhap";
            this.rpt_ThongKeTheoMaPhieuNhap.ReportSource = this.InThongKeTheoMaPhieuNhap1;
            this.rpt_ThongKeTheoMaPhieuNhap.Size = new System.Drawing.Size(1247, 608);
            this.rpt_ThongKeTheoMaPhieuNhap.TabIndex = 1;
            this.rpt_ThongKeTheoMaPhieuNhap.ToolPanelWidth = 267;
            // 
            // frm_ThongKeTheoMaPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 662);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_ThongKeTheoMaPhieuNhap";
            this.Text = "Thống kê theo mã phiếu nhập";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_ThongKeTheoMaPhieuNhap_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private InThongKeTheoMaPhieuNhap InThongKeTheoMaPhieuNhap1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMaPhieuNhap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rpt_ThongKeTheoMaPhieuNhap;
        private System.Windows.Forms.Button btnTim;
    }
}