using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SieuThiBHX
{
    public partial class frm_InHD : Form
    {
        string maHd = string.Empty;

        public frm_InHD()
        {
            InitializeComponent();
        }
        public frm_InHD(string id)
        {
            maHd = id;
            InitializeComponent();
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            if (maHd != "")
            {
                // Khởi tạo đối tượng rpt
                GetHdByMaHd rpt = new GetHdByMaHd();

                // Khởi tạo ParameterValues
                ParameterValues para = new ParameterValues();

                // Khởi tạo ParameterDiscreteValue
                ParameterDiscreteValue val = new ParameterDiscreteValue();

                // Gán giá trị cho ParameterDiscreteValue
                val.Value = maHd;

                // Thêm val vào para
                para.Add(val);

                // Định nghĩa biến tham gia cho rpt
                rpt.DataDefinition.ParameterFields["@maHoaDon"].ApplyCurrentValues(para);

                // Gọi rpt
                crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}
