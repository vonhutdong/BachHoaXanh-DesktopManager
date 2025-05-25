using CrystalDecisions.Shared;
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
using DTO;

namespace SieuThiBHX.Trong
{
    public partial class frm_ThongKeTheoMaPhieuNhap : Form
    {
        public frm_ThongKeTheoMaPhieuNhap()
        {
            InitializeComponent();
        }
        BUS_PhieuNhapAll bus = new BUS_PhieuNhapAll();
        private void LoadMaPhieuNhap()
        {
            cboMaPhieuNhap.DataSource = bus.LayDSPhieuNhap();
            cboMaPhieuNhap.DisplayMember = "MaPhieuNhap";
            cboMaPhieuNhap.ValueMember = "ID";
            cboMaPhieuNhap.SelectedIndex = 0;
        }
        
        
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboMaPhieuNhap.Text))
            {
                MessageBox.Show("Vui lòng chọn mã phiếu nhập.");
                return;
            }

            // Khởi tạo report
            InThongKeTheoMaPhieuNhap rpt = new InThongKeTheoMaPhieuNhap();

            // Tạo tham số
            ParameterValues para = new ParameterValues();
            ParameterDiscreteValue val = new ParameterDiscreteValue();
            val.Value = cboMaPhieuNhap.Text.Trim(); // ✅ Gán đúng giá trị
            para.Add(val);

            // Gán vào report parameter
            rpt.DataDefinition.ParameterFields["@MaPhieuNhap"].ApplyCurrentValues(para);

            // Gán cho CrystalReportViewer
            rpt_ThongKeTheoMaPhieuNhap.ReportSource = rpt;
        }

        private void frm_ThongKeTheoMaPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadMaPhieuNhap();
        }

        private void frm_ThongKeTheoMaPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
