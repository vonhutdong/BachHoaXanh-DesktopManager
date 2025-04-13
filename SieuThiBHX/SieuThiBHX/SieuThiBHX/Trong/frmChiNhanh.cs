using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiBHX.Trong
{
    public partial class frmChiNhanh : Form
    {
        //bus chi nhanh
        BUS_ChiNhanh bus_chinhanh = new BUS_ChiNhanh();
        //id đang chọn
        int currentID = 0;
        public frmChiNhanh()
        {
            InitializeComponent();
        }

        private void frmChiNhanh_Load(object sender, EventArgs e)
        {
            LoadDSChiNhanh();
        }
        private void LoadDSChiNhanh()
        {
            dgvChiNhanh.DataSource = bus_chinhanh.LayDSChiNhanh();
            //dổi tên cột
            dgvChiNhanh.Columns["MaChiNhanh"].HeaderText = "Mã chi nhánh";
            dgvChiNhanh.Columns["TenChiNhanh"].HeaderText = "Tên chi nhánh";
            dgvChiNhanh.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvChiNhanh.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            //ẩn cột
            dgvChiNhanh.Columns["id"].Visible = false;
        }
    }
}
