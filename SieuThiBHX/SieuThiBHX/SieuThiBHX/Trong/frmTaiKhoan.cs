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
    public partial class frmTaiKhoan : Form
    {
        BUS_TaiKhoan bus_tk = new BUS_TaiKhoan();
        int quyen = -1;

        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        public void LoadData()
        {     
            dgvDanhSachTaiKhoan.DataSource = bus_tk.GetListTaiKhoan();
            dgvDanhSachTaiKhoan.Columns["MaTaiKhoan"].Visible = true;
            dgvDanhSachTaiKhoan.Columns[0].HeaderText = "Id";
            dgvDanhSachTaiKhoan.Columns[1].HeaderText = "Mã tài khoản";
            dgvDanhSachTaiKhoan.Columns[2].HeaderText = "Tên tài khoản";
            dgvDanhSachTaiKhoan.Columns[3].HeaderText = "Mật khẩu";
            dgvDanhSachTaiKhoan.Columns[4].HeaderText = "Quyền";
            dgvDanhSachTaiKhoan.Columns["id"].Visible = false;
            dgvDanhSachTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachTaiKhoan.ColumnHeadersHeight = 40; // hoặc cao hơn

            // Thiết lập lại style để dữ liệu hiện rõ
            dgvDanhSachTaiKhoan.DefaultCellStyle.BackColor = Color.White;
            dgvDanhSachTaiKhoan.DefaultCellStyle.ForeColor = Color.Black;
            dgvDanhSachTaiKhoan.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvDanhSachTaiKhoan.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvDanhSachTaiKhoan.EnableHeadersVisualStyles = false;
            dgvDanhSachTaiKhoan.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvDanhSachTaiKhoan.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

        }
        private void ResetForm()
        {
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            cboQuyen.SelectedIndex = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dgvDanhSachTaiKhoan.ClearSelection();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {

            LoadData();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            cboQuyen.Items.Clear();
            cboQuyen.Items.Add("Admin");
            cboQuyen.Items.Add("Nhân viên");
            cboQuyen.SelectedIndex = 0; // Mặc định
        }

        private void dgvDanhSachTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                var row = dgvDanhSachTaiKhoan.Rows[index];

                txtTenTaiKhoan.Text = row.Cells["TenTaiKhoan"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                cboQuyen.SelectedIndex = (int)row.Cells["Quyen"].Value == 0 ? 0 : 1;

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu
                if (string.IsNullOrWhiteSpace(txtTenTaiKhoan.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int quyen = cboQuyen.SelectedIndex; // 0: Admin, 1: Nhân viên

                DTO_TaiKhoan newTaiKhoan = new DTO_TaiKhoan
                {
                    TenTaiKhoan = txtTenTaiKhoan.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    Quyen = quyen
                };

                bus_tk.AddTaiKhoan(newTaiKhoan);

                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
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
                if (dgvDanhSachTaiKhoan.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dgvDanhSachTaiKhoan.CurrentRow.Cells["id"].Value);
                    string tenTK = txtTenTaiKhoan.Text.Trim();
                    string matKhau = txtMatKhau.Text.Trim();
                    int quyen = cboQuyen.SelectedIndex;

                    if (string.IsNullOrWhiteSpace(tenTK) || string.IsNullOrWhiteSpace(matKhau))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DTO_TaiKhoan tk = new DTO_TaiKhoan
                    {
                        Id = id,
                        TenTaiKhoan = tenTK,
                        MatKhau = matKhau,
                        Quyen = quyen
                    };

                    bus_tk.UpdateTaiKhoan(tk);
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDanhSachTaiKhoan.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dgvDanhSachTaiKhoan.CurrentRow.Cells["id"].Value);
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bus_tk.DeleteTaiKhoan(id);
                        MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ResetForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void frmTaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
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

