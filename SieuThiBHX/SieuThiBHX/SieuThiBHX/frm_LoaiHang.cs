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
using System.Configuration;
using DAL;

namespace SieuThiBHX
{
    public partial class frm_LoaiHang : Form
    {
        public frm_LoaiHang()
        {
            InitializeComponent();
        }
        BUS_LoaiHang bus_lh= new BUS_LoaiHang();
        int currentID = -1;
        public void LoadDSLoaiHang()
        {
            //load danh sách
            dgvLoaiHang.DataSource = bus_lh.LayDSLH();
            //đổi tên cột
            dgvLoaiHang.Columns["MaLoaiHang"].HeaderText = "Mã Loại Hàng";
            dgvLoaiHang.Columns["TenLoaiHang"].HeaderText = "Tên Loại Hàng";
            //ẩn cột id
            dgvLoaiHang.Columns["id"].Visible = false;
        }

        private void dgvLoaiHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void frm_LoaiHang_Load(object sender, EventArgs e)
        {
            LoadDSLoaiHang();
        }

        private void dgvLoaiHang_Click(object sender, EventArgs e)
        {
            int dong = dgvLoaiHang.CurrentRow.Index;
            //điền thông tin lên textbox
            txtMaLH.Text = dgvLoaiHang.Rows[dong].Cells["MaLoaiHang"].Value.ToString();
            txtTenLH.Text = dgvLoaiHang.Rows[dong].Cells["TenLoaiHang"].Value.ToString();
            //lấy id click
            currentID = int.Parse(dgvLoaiHang.Rows[dong].Cells["id"].Value.ToString());
        }
    }
}
