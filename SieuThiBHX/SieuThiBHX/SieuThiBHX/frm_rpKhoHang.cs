using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;


namespace SieuThiBHX
{
    public partial class frm_rpKhoHang : Form
    {
        public frm_rpKhoHang()
        {
            InitializeComponent();
        }
        BUS_KhoHang bus_kh = new BUS_KhoHang();
        
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            // B1: Load dữ liệu mới từ DB
            // Load data mới nhất
            DataTable dt = bus_kh.LoadReportData();

            // Tạo mới report từ class (được build sẵn)
            rpKhoHang rpt = new rpKhoHang();
            rpt.SetDataSource(dt);

            // Gán vào viewer
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.RefreshReport();

        }
    }
}
