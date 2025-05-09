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
using DTO;

namespace SieuThiBHX
{
    public partial class frm_KhoHang : Form
    {
        public frm_KhoHang()
        {
            InitializeComponent();

        }
        BUS_SanPham bus_sp = new BUS_SanPham();
        BUS_KhoHang bus_kh = new BUS_KhoHang();
        int currentID = 0;
        private void LamMoi()
        {
            cbTenSP.SelectedIndex = 0;
            txtSoLuong.Clear();
            LoadKhoHang();
        }
        private void LoadCBTenSanPham()
        {
            // đổ dữ liệu cho combobox sản phẩm
            cbTenSP.DataSource = bus_sp.LoadDSSanPham();
            cbTenSP.ValueMember = "id";               
            cbTenSP.DisplayMember = "TenSanPham";     
        }

        private void LoadKhoHang()
        {
            dgvKhoHang.DataSource = bus_kh.LoadKhoHang();

            // Đổi header
            dgvKhoHang.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvKhoHang.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";

            // Ẩn cột ID và idSanPham
            dgvKhoHang.Columns["id"].Visible = false;
            dgvKhoHang.Columns["idSanPham"].Visible = false;

            dgvKhoHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhoHang.ColumnHeadersHeight = 30; // hoặc cao hơn

            // Thiết lập lại style để dữ liệu hiện rõ
            dgvKhoHang.DefaultCellStyle.BackColor = Color.White;
            dgvKhoHang.DefaultCellStyle.ForeColor = Color.Black;
            dgvKhoHang.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvKhoHang.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvKhoHang.EnableHeadersVisualStyles = false;
            dgvKhoHang.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvKhoHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        private void frm_KhoHang_Click(object sender, EventArgs e)
        {
            
        }

        private void frm_KhoHang_Load(object sender, EventArgs e)
        {
            LoadKhoHang();
            LoadCBTenSanPham();

            btnThem.Enabled = false;
            btnXoa.Enabled = false;

        }

        private void dgvKhoHang_Click(object sender, EventArgs e)
        {
            int dong = dgvKhoHang.CurrentRow.Index;
            txtSoLuong.Text = dgvKhoHang.Rows[dong].Cells["SoLuong"].Value.ToString();
            cbTenSP.SelectedValue = int.Parse(dgvKhoHang.Rows[dong].Cells["idSanPham"].Value.ToString());
            currentID = int.Parse(dgvKhoHang.Rows[dong].Cells["id"].Value.ToString());

        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTenSP.SelectedValue != null && txtSoLuong.Text.Length > 0)
                {
                    int idSP = int.Parse(cbTenSP.SelectedValue.ToString());
                    int soLuongMoi = int.Parse(txtSoLuong.Text);

                    DTO_KhoHang kh = new DTO_KhoHang(0, idSP, soLuongMoi);
                    bus_kh.SuaKhoHang(kh);

                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm và nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void OpenRpKhoHangForm()
        {
            frm_rpKhoHang frm = new frm_rpKhoHang();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            this.Controls.Clear();            // Xóa control cũ nếu muốn
            this.Controls.Add(frm);           // Nhúng form vào panel chính hoặc form
            frm.BringToFront();
            frm.Show();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenRpKhoHangForm();
        }
    }
}
