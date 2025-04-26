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

namespace SieuThiBHX.NhutDong
{
    public partial class frmTraCuuNV : Form
    {
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        public frmTraCuuNV()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            // dgvTim
            dgvTim.DataSource = bus_nv.GetListNV2();
            dgvTim.Columns[0].HeaderText = "Id";
            dgvTim.Columns[1].HeaderText = "Mã nhân viên";
            dgvTim.Columns[2].HeaderText = "Tên nhân viên";
            dgvTim.Columns[3].HeaderText = "Số điện thoại";
            dgvTim.Columns[4].HeaderText = "Địa chỉ";
            dgvTim.Columns[0].Visible = false;

            // Others
            txtTim.Text = string.Empty;
            txtTim.Focus();
            cboTim.SelectedIndex = 0;

            dgvTim.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTim.ColumnHeadersHeight = 30; // hoặc cao hơn

            // Thiết lập lại style để dữ liệu hiện rõ
            dgvTim.DefaultCellStyle.BackColor = Color.White;
            dgvTim.DefaultCellStyle.ForeColor = Color.Black;
            dgvTim.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvTim.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvTim.EnableHeadersVisualStyles = false;
            dgvTim.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvTim.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

        }

        public void Reset()
        {
            LoadData();
        }
        private void frmTraCuuNV_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void frmTraCuuNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn thoát form không?", "Thông báo",
             MessageBoxButtons.OKCancel,
             MessageBoxIcon.Warning);

            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (cboTim.SelectedIndex == 0)
            {
                // dgvTim
                dgvTim.DataSource = bus_nv.SearchNvByMaNV(txtTim.Text);
                dgvTim.Columns[0].HeaderText = "Id";
                dgvTim.Columns[1].HeaderText = "Mã nhân viên";
                dgvTim.Columns[2].HeaderText = "Tên nhân viên";
                dgvTim.Columns[3].HeaderText = "Số điện thoại";
                dgvTim.Columns[4].HeaderText = "Địa chỉ";
                dgvTim.Columns[0].Visible = false;
            }
            else
            {
                // dgvTim
                dgvTim.DataSource = bus_nv.SearchNvBytenNV(txtTim.Text);
                dgvTim.Columns[0].HeaderText = "Id";
                dgvTim.Columns[1].HeaderText = "Mã nhân viên";
                dgvTim.Columns[2].HeaderText = "Tên nhân viên";
                dgvTim.Columns[3].HeaderText = "Số điện thoại";
                dgvTim.Columns[4].HeaderText = "Địa chỉ";
                dgvTim.Columns[0].Visible = false;
            }
        }
    }
}
