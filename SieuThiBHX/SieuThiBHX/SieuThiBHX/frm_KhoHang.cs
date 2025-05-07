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

namespace SieuThiBHX
{
    public partial class frm_KhoHang : Form
    {
        public frm_KhoHang()
        {
            InitializeComponent();
        }
        BUS_KhoHang bus_kh = new BUS_KhoHang();
        int currentID = 0;
        private void LoadKhoHang()
        {
            //goi bus kho hàng
            dgvKhoHang.DataSource = bus_kh.LoadKhoHang();
            //đổi tên header
            dgvKhoHang.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvKhoHang.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            //ẩn côt
            dgvKhoHang.Columns["id"].Visible = false;
            dgvKhoHang.Columns["idSanPham"].Visible = false;
        }

        private void frm_KhoHang_Click(object sender, EventArgs e)
        {
            
        }

        private void frm_KhoHang_Load(object sender, EventArgs e)
        {
            LoadKhoHang();
        }
    }
}
