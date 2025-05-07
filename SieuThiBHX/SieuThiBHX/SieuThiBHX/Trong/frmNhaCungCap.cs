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
    public partial class frmNhaCungCap : Form
    {
        BUS_NhaCungCap bus_ncc = new BUS_NhaCungCap();
        string data_olds = string.Empty;
        string data_news = string.Empty;
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            txtTenNCC.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvNCC.DataSource = bus_ncc.LayDSNCC();
            dgvNCC.Columns["id"].Visible = false;
            dgvNCC.Columns["MaNCC"].HeaderText = "Mã nhà cung cấp";
            dgvNCC.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
            dgvNCC.Columns["SDT"].HeaderText = "Số điện thoại";
            dgvNCC.Columns["DiaChi"].HeaderText = "Địa chỉ";

            

            // Thiết lập lại style để dữ liệu hiện rõ
            dgvNCC.DefaultCellStyle.BackColor = Color.White;
            dgvNCC.DefaultCellStyle.ForeColor = Color.Black;
            dgvNCC.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvNCC.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvNCC.EnableHeadersVisualStyles = false;
            dgvNCC.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvNCC.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTenNCC.Text = dgvNCC.Rows[e.RowIndex].Cells["TenNCC"].Value.ToString();
                txtSDT.Text = dgvNCC.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
                txtDiaChi.Text = dgvNCC.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
        // checknumberphone
        public bool CheckNumberPhone(string n)
        {
            if (n == string.Empty)
            {
                return false;
            }
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] >= '0' && n[i] <= '9' && n.Length == 10)
                {
                    return true;
                }
            }
            return false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenNCC.Text.Length > 0)
                {
                    if (CheckNumberPhone(txtSDT.Text))
                    {
                        if (txtDiaChi.Text.Length > 0)
                        {
                            //thêm NhaCungCap
                            bus_ncc.ThemNCC(new DTO_NhaCungCap(txtTenNCC.Text, txtSDT.Text, txtDiaChi.Text));
                            MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //làm mới

                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập địa chỉ!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại phải là số và có 10 kí tự!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên nhà cung cấp!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //thông báo khi có lỗi xảy ra
                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNCC.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dgvNCC.CurrentRow.Cells["id"].Value);
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này không?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bus_ncc.XoaNCC(id);
                        MessageBox.Show("Xóa  nhà cung cấp thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNCC.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dgvNCC.CurrentRow.Cells["id"].Value);
                    string tenNCC = txtTenNCC.Text.Trim();
                    string soDienThoai = txtSDT.Text.Trim();
                    string diaChi = txtDiaChi.Text.Trim();

                    // Kiểm tra nếu có trường nào còn trống
                    if (string.IsNullOrWhiteSpace(tenNCC) || string.IsNullOrWhiteSpace(soDienThoai) || string.IsNullOrWhiteSpace(diaChi))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhà cung cấp.", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tạo đối tượng DTO_NhaCungCap và cập nhật
                    DTO_NhaCungCap ncc = new DTO_NhaCungCap
                    {
                        Id = id,
                        TenNhaCungCap = tenNCC,
                        SoDienThoai = soDienThoai,
                        DiaChi = diaChi
                    };

                    // Gọi phương thức cập nhật trong BUS
                    bus_ncc.SuaNCC(ncc);

                    MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại dữ liệu nhà cung cấp vào DataGridView
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();

            // Đặt lại trạng thái nút
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void frmNhaCungCap_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
