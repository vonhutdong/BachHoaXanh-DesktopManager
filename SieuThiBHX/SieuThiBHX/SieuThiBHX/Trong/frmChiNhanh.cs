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

            txtMaChiNhanh.Focus();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
          
            dgvChiNhanh.DataSource = bus_chinhanh.LayDSChiNhanh();
            //dổi tên cột
            dgvChiNhanh.Columns["MaChiNhanh"].HeaderText = "Mã chi nhánh";
            dgvChiNhanh.Columns["TenChiNhanh"].HeaderText = "Tên chi nhánh";
            dgvChiNhanh.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvChiNhanh.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            //ẩn cột
            dgvChiNhanh.Columns["id"].Visible = false;
            dgvChiNhanh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiNhanh.ColumnHeadersHeight = 40; // hoặc cao hơn

            // Thiết lập lại style để dữ liệu hiện rõ
            dgvChiNhanh.DefaultCellStyle.BackColor = Color.White;
            dgvChiNhanh.DefaultCellStyle.ForeColor = Color.Black;
            dgvChiNhanh.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvChiNhanh.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvChiNhanh.EnableHeadersVisualStyles = false;
            dgvChiNhanh.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvChiNhanh.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nhập đầy đủ
                if (string.IsNullOrWhiteSpace(txtMaChiNhanh.Text) ||
                    string.IsNullOrWhiteSpace(txtTenChiNhanh.Text) ||
                    string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                    string.IsNullOrWhiteSpace(txtDiaChi.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo DTO và gửi đi
                DTO_ChiNhanh chiNhanh = new DTO_ChiNhanh(
                    txtMaChiNhanh.Text.Trim(),
                    txtTenChiNhanh.Text.Trim(),
                    txtDiaChi.Text.Trim(),
                    txtSoDienThoai.Text.Trim()
                );

                // Gọi BUS để thêm
                bus_chinhanh.themChiNhanh(chiNhanh);

                MessageBox.Show("Thêm chi nhánh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới form
                LoadDSChiNhanh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            //làm mới txt
            txtMaChiNhanh.Focus();
            txtMaChiNhanh.Clear();
            txtTenChiNhanh.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            //load lai chi nhanh
            LoadDSChiNhanh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentID > 0)
            {
                //Hỏi
                DialogResult resuflt = MessageBox.Show("Có chắc xóa dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resuflt == DialogResult.Yes)
                {
                    //gọi hàm xóa chi nhánh
                    bus_chinhanh.xoaChiNhanh(currentID);
                    //Thông báo
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    //làm mới
                    LoadDSChiNhanh();
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaChiNhanh.Text.Length > 0
                    && txtTenChiNhanh.Text.Length > 0
                    && txtSoDienThoai.Text.Length > 0
                    && txtDiaChi.Text.Length > 0)
                {
                    //thêm loại hàng
                    bus_chinhanh.suaChinhNhanh(new DTO_ChiNhanh(currentID, txtMaChiNhanh.Text, txtTenChiNhanh.Text, txtDiaChi.Text, txtSoDienThoai.Text));
                    MessageBox.Show("Sửa thành công!", "Thoát", MessageBoxButtons.OK);
                    //làm mới
                    LoadDSChiNhanh();
                }
                else
                {
                    //thông báo khi chưa đầy đủ dữ liệu
                    MessageBox.Show("Chưa nhập dữ liệu!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //thông báo khi có lỗi xảy ra
                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar != Keys.Back && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                txtSoDienThoai.Focus();
            }
        }

        private void frmChiNhanh_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChiNhanh_Click(object sender, EventArgs e)
        {
            //lấy dòng đang click
            int dong = dgvChiNhanh.CurrentRow.Index;
            //điền thông tin lên textbox
            txtMaChiNhanh.Text = dgvChiNhanh.Rows[dong].Cells["MaChiNhanh"].Value.ToString();
            txtTenChiNhanh.Text = dgvChiNhanh.Rows[dong].Cells["TenChiNhanh"].Value.ToString();
            txtDiaChi.Text = dgvChiNhanh.Rows[dong].Cells["DiaChi"].Value.ToString();
            txtSoDienThoai.Text = dgvChiNhanh.Rows[dong].Cells["SoDienThoai"].Value.ToString();
            //gán id cho currnentID
            currentID = int.Parse(dgvChiNhanh.Rows[dong].Cells["id"].Value.ToString());

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}
