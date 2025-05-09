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

namespace SieuThiBHX
{
    public partial class frm_KhachHang : Form
    {
        public frm_KhachHang()
        {
            InitializeComponent();
        }
        BUS_KhachHang bus_kh = new BUS_KhachHang();
        int currentID = -1;
        private void LoadData()
        {
            //load data
            dgvDSKH.DataSource = bus_kh.LayDSKH();
            //đổi tên cột
            dgvDSKH.Columns["MaKH"].HeaderText = "Mã khách hàng";
            dgvDSKH.Columns["TenKH"].HeaderText = "Tên khách hàng";
            dgvDSKH.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvDSKH.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvDSKH.Columns["Diem"].HeaderText = "Điểm";
            dgvDSKH.Columns["id"].Visible = false;
            lblMaKH.Visible = false;
            txtMaKH.Visible = false;

        }
        private void Reset()
        {
            txtTenKH.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDiem.Text = string.Empty;
        }



        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public bool CheckNumberPhone(string n)
        {
            return n.Length == 10 && n.All(char.IsDigit);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (!CheckNumberPhone(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo DTO và thêm
            DTO_KhachHang kh = new DTO_KhachHang(
                txtTenKH.Text.Trim(),
                txtSDT.Text.Trim(),
                txtDiaChi.Text.Trim(),
                int.Parse(txtDiem.Text.Trim())
            );

            if (bus_kh.ThemKhachHang(kh))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ID khách hàng từ dòng đang chọn
                int currentId = int.Parse(dgvDSKH.CurrentRow.Cells[0].Value.ToString());

                if (CheckNumberPhone(txtSDT.Text))
                {
                    DialogResult dr = MessageBox.Show(
                        $"Bạn có chắc muốn xóa: [{txtTenKH.Text}] không?",
                        "Thông báo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        // Xóa khách hàng (xóa thật)
                        bus_kh.XoaKH(currentId);
                        Reset();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ!", "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            LoadData();
        }

        private void dgvDSKH_Click(object sender, EventArgs e)
        {
            int dong = dgvDSKH.CurrentRow.Index;

            // Lưu ID vào biến để dùng khi cập nhật
            currentID = int.Parse(dgvDSKH.Rows[dong].Cells["id"].Value.ToString());

            txtTenKH.Text = dgvDSKH.Rows[dong].Cells["TenKH"].Value.ToString();
            txtSDT.Text = dgvDSKH.Rows[dong].Cells["SoDienThoai"].Value.ToString();
            txtDiaChi.Text = dgvDSKH.Rows[dong].Cells["DiaChi"].Value != null
            ? dgvDSKH.Rows[dong].Cells["DiaChi"].Value.ToString()
    :        string.Empty;
            txtDiem.Text = dgvDSKH.Rows[dong].Cells["Diem"].Value.ToString();


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CheckNumberPhone(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại phải là số và có độ dài là 10 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                MessageBox.Show("Điểm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DTO_KhachHang kh = new DTO_KhachHang(
                    currentID,
                    txtTenKH.Text.Trim(),
                    txtSDT.Text.Trim(),
                    txtDiaChi.Text.Trim(),
                    int.Parse(txtDiem.Text.Trim())
                );

                if (bus_kh.SuaKH(kh))
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemKH.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }

            var result = bus_kh.TimKiemTheoTenHoacSDT(keyword).ToList();
            dgvDSKH.DataSource = result;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
