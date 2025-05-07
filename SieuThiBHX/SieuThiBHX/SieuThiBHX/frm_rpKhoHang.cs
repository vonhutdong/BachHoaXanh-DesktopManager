using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace SieuThiBHX
{
    public partial class frm_rpKhoHang : Form
    {
        public frm_rpKhoHang()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DAL_KhoHang dal = new DAL_KhoHang();
            DataTable dt = dal.GetKhoHangDataTable();

            rpKhoHang rpt = new rpKhoHang(); // tên .rpt file
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
