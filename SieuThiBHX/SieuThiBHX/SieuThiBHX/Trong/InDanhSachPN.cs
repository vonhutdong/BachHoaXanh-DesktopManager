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

namespace SieuThiBHX.Trong
{
    public partial class frm_InDanhSachPN : Form
    {
        public frm_InDanhSachPN()
        {
            InitializeComponent();
        }

        private void frm_InDanhSachPN_Load(object sender, EventArgs e)
        {
            BUS_PhieuNhapAll bus = new BUS_PhieuNhapAll();
            DataTable data = bus.LayDSPhieuNhapVaChiTiet_BaoCao();

            InDSPhieuNhap rpt = new InDSPhieuNhap(); // file Crystal Report đã tạo sẵn
            rpt.SetDataSource(data);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }

        private void frm_InDanhSachPN_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
